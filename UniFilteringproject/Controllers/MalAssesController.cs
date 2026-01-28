using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Data;
using UniFilteringproject.Models;

namespace UniFilteringproject.Controllers
{
    public class MalAssesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MalAssesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.MalAss
                .Include(m => m.Malshab)
                .Include(m => m.Assignment)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var malAss = await _context.MalAss
                .Include(m => m.Assignment)
                .Include(m => m.Malshab)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (malAss == null) return NotFound();

            return View(malAss);
        }

        // GET: MalAsses/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name");
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name");
            return View();
        }

        // POST: MalAsses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MalshabId,AssignmentId")] MalAss malAss)
        {
            // Set the source manually
            malAss.AssignedBy = "Manual";

            // We clear errors for navigation properties and AssignedBy because they are set server-side
            ModelState.Remove("Malshab");
            ModelState.Remove("Assignment");
            ModelState.Remove("AssignedBy");

            if (ModelState.IsValid)
            {
                _context.Add(malAss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name", malAss.AssignmentId);
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name", malAss.MalshabId);
            return View(malAss);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var malAss = await _context.MalAss.FindAsync(id);
            if (malAss == null) return NotFound();

            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name", malAss.AssignmentId);
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name", malAss.MalshabId);
            return View(malAss);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MalshabId,AssignmentId")] MalAss malAss)
        {
            if (id != malAss.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(malAss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalAssExists(malAss.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(malAss);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var malAss = await _context.MalAss
                .Include(m => m.Assignment)
                .Include(m => m.Malshab)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (malAss == null) return NotFound();

            return View(malAss);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var malAss = await _context.MalAss.FindAsync(id);
            if (malAss != null) _context.MalAss.Remove(malAss);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearAssignments()
        {
            var allAssignments = await _context.MalAss.ToListAsync();
            if (allAssignments.Any())
            {
                _context.MalAss.RemoveRange(allAssignments);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "All assignments have been cleared.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RunAutoAssignment()
        {
            // 1. Load Data
            var allMalshabs = await _context.Malshabs.Include(m => m.MalAbis).ToListAsync();
            var allAssignments = await _context.Assignments.ToListAsync();
            var allRequirements = await _context.AssAbi.ToListAsync();
            var existingAssignments = await _context.MalAss.ToListAsync();
            // Note: Ensuring we use the correct model name 'MalshabBlocks' as per your latest context
            var allBlocks = await _context.MalBlocks.ToListAsync();

            // 2. Setup Tracking (Preserve existing)
            var currentTracking = allAssignments.ToDictionary(a => a.Id, a => new List<Malshab>());
            var globalAssignedIds = new HashSet<int>();

            // NEW: Keep track of which Malshab IDs were manually assigned
            var manualAssignedIds = new HashSet<int>();

            foreach (var existing in existingAssignments)
            {
                var malshab = allMalshabs.FirstOrDefault(m => m.Id == existing.MalshabId);
                // Ensure the malshab exists and isn't already processed
                if (malshab != null && currentTracking.ContainsKey(existing.AssignmentId) && !globalAssignedIds.Contains(malshab.Id))
                {
                    currentTracking[existing.AssignmentId].Add(malshab);
                    globalAssignedIds.Add(malshab.Id);

                    // If it was already in the DB, it's considered Manual (or was previously set as Manual)
                    // We preserve this status.
                    manualAssignedIds.Add(malshab.Id);
                }
            }

            // 3. Define the Pools (Respecting Blocks)
            var assignmentPools = allAssignments.Select(ass => new {
                Assignment = ass,
                Pool = allMalshabs.Where(m =>
                    !globalAssignedIds.Contains(m.Id) &&
                    !allBlocks.Any(b => b.MalshabId == m.Id && b.AssignmentId == ass.Id) &&
                    m.Dapar >= ass.DaparNeeded &&
                    m.Profile >= ass.ProfileNeeded &&
                    allRequirements.Where(r => r.AssignmentId == ass.Id)
                        .All(req => m.MalAbis.Any(ma => ma.AbilityId == req.AbilityId && ma.AbiLevel >= req.AbiLevel))
                ).ToList()
            })
            .OrderBy(x => x.Pool.Count).ToList();

            // 4. Fill to Minimum
            foreach (var item in assignmentPools)
            {
                int currentCount = currentTracking[item.Assignment.Id].Count;
                int needed = item.Assignment.MinMalshabs - currentCount;
                if (needed > 0)
                {
                    var toAssign = item.Pool.Where(p => !globalAssignedIds.Contains(p.Id)).Take(needed).ToList();
                    foreach (var m in toAssign)
                    {
                        currentTracking[item.Assignment.Id].Add(m);
                        globalAssignedIds.Add(m.Id);
                    }
                }
            }

            // 5. Stealing Logic (Respecting Blocks)
            foreach (var item in assignmentPools)
            {
                var target = item.Assignment;
                int currentCount = currentTracking[target.Id].Count;

                if (currentCount < target.MinMalshabs)
                {
                    var candidates = allMalshabs
                        .Where(m => globalAssignedIds.Contains(m.Id))
                        .Where(m => !allBlocks.Any(b => b.MalshabId == m.Id && b.AssignmentId == target.Id))
                        .Where(m => m.Dapar >= target.DaparNeeded && m.Profile >= target.ProfileNeeded &&
                                    allRequirements.Where(r => r.AssignmentId == target.Id)
                                    .All(req => m.MalAbis.Any(ma => ma.AbilityId == req.AbilityId && ma.AbiLevel >= req.AbiLevel)))
                        .Select(m => new {
                            Malshab = m,
                            SourceId = currentTracking.FirstOrDefault(kv => kv.Value.Any(mal => mal.Id == m.Id)).Key
                        })
                        .Where(x => x.SourceId != 0 && x.SourceId != target.Id)
                        .Where(x => {
                            var sourceAss = allAssignments.First(a => a.Id == x.SourceId);
                            return currentTracking[x.SourceId].Count > sourceAss.MinMalshabs;
                        })
                        .ToList();

                    foreach (var c in candidates)
                    {
                        if (currentCount >= target.MinMalshabs) break;

                        var malToMove = currentTracking[c.SourceId].First(m => m.Id == c.Malshab.Id);
                        currentTracking[c.SourceId].Remove(malToMove);
                        currentTracking[target.Id].Add(malToMove);
                        currentCount++;
                    }
                }
            }

            // 6. Fill Remaining (Balance Load & Respect Blocks)
            var remaining = allMalshabs.Where(m => !globalAssignedIds.Contains(m.Id)).ToList();
            foreach (var m in remaining)
            {
                var validAss = allAssignments.Where(ass =>
                    !allBlocks.Any(b => b.MalshabId == m.Id && b.AssignmentId == ass.Id) &&
                    m.Dapar >= ass.DaparNeeded && m.Profile >= ass.ProfileNeeded &&
                    allRequirements.Where(r => r.AssignmentId == ass.Id)
                        .All(req => m.MalAbis.Any(ma => ma.AbilityId == req.AbilityId && ma.AbiLevel >= req.AbiLevel))
                ).OrderBy(a => currentTracking[a.Id].Count).FirstOrDefault();

                if (validAss != null)
                {
                    currentTracking[validAss.Id].Add(m);
                    globalAssignedIds.Add(m.Id);
                }
            }

            // Messages Logic
            var failedAssignments = allAssignments
                .Where(a => currentTracking[a.Id].Count < a.MinMalshabs)
                .Select(a => a.Name)
                .ToList();

            if (failedAssignments.Any())
            {
                TempData["ErrorMessage"] = "There weren't enough malshabs for: " + string.Join(", ", failedAssignments);
            }
            else
            {
                TempData["SuccessMessage"] = "Auto-assignment completed successfully.";
            }

            // 7. Save to DB
            _context.MalAss.RemoveRange(_context.MalAss);
            await _context.SaveChangesAsync();

            foreach (var kvp in currentTracking)
            {
                foreach (var m in kvp.Value)
                {
                    _context.MalAss.Add(new MalAss
                    {
                        MalshabId = m.Id,
                        AssignmentId = kvp.Key,
                        // NEW: Logic to set the source
                        AssignedBy = manualAssignedIds.Contains(m.Id) ? "Manual" : "Algorithm"
                    });
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalAssExists(int id) => _context.MalAss.Any(e => e.Id == id);
    }
}