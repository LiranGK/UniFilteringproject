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

        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name");
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MalshabId,AssignmentId")] MalAss malAss)
        {
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
        public async Task<IActionResult> RunAutoAssignment()
        {
            // 1. Load Data
            var allMalshabs = await _context.Malshabs.Include(m => m.MalAbis).ToListAsync();
            var allAssignments = await _context.Assignments.ToListAsync();
            var allRequirements = await _context.AssAbi.ToListAsync();
            var existingAssignments = await _context.MalAss.ToListAsync();

            // 2. Setup Tracking with EXISTING assignments (Requirement #1)
            var currentTracking = allAssignments.ToDictionary(a => a.Id, a => new List<Malshab>());
            var globalAssignedIds = new HashSet<int>();

            foreach (var existing in existingAssignments)
            {
                var malshab = allMalshabs.FirstOrDefault(m => m.Id == existing.MalshabId);
                // Fix Bug 1: Ensure we don't track the same Malshab in multiple existing slots
                if (malshab != null && currentTracking.ContainsKey(existing.AssignmentId) && !globalAssignedIds.Contains(malshab.Id))
                {
                    currentTracking[existing.AssignmentId].Add(malshab);
                    globalAssignedIds.Add(malshab.Id);
                }
            }

            // 3. Define the Pools
            var assignmentPools = allAssignments.Select(ass => new {
                Assignment = ass,
                Pool = allMalshabs.Where(m =>
                    !globalAssignedIds.Contains(m.Id) &&
                    m.Dapar >= ass.DaparNeeded &&
                    m.Profile >= ass.ProfileNeeded &&
                    allRequirements.Where(r => r.AssignmentId == ass.Id)
                        .All(req => m.MalAbis.Any(ma => ma.AbilityId == req.AbilityId && ma.AbiLevel >= req.AbiLevel))
                ).ToList()
            })
            .OrderBy(x => x.Pool.Count)
            .ToList();

            // 4. Fill to Minimum (Pass 1)
            foreach (var item in assignmentPools)
            {
                var target = item.Assignment;
                int currentCount = currentTracking[target.Id].Count;
                int needed = target.MinMalshabs - currentCount;

                if (needed > 0)
                {
                    // Refresh pool to exclude people assigned during this loop
                    var toAssign = item.Pool.Where(p => !globalAssignedIds.Contains(p.Id)).Take(needed).ToList();
                    foreach (var m in toAssign)
                    {
                        currentTracking[target.Id].Add(m);
                        globalAssignedIds.Add(m.Id);
                    }
                }
            }

            // 5. Stealing Logic (Pass 2)
            foreach (var item in assignmentPools)
            {
                var target = item.Assignment;
                int currentCount = currentTracking[target.Id].Count;

                if (currentCount < target.MinMalshabs)
                {
                    var candidatesToSteal = allMalshabs
                        .Where(m => globalAssignedIds.Contains(m.Id))
                        .Where(m => m.Dapar >= target.DaparNeeded && m.Profile >= target.ProfileNeeded &&
                                    allRequirements.Where(r => r.AssignmentId == target.Id)
                                    .All(req => m.MalAbis.Any(ma => ma.AbilityId == req.AbilityId && ma.AbiLevel >= req.AbiLevel)))
                        .Select(m => new {
                            Malshab = m,
                            SourceAssId = currentTracking.FirstOrDefault(kvp => kvp.Value.Any(mal => mal.Id == m.Id)).Key
                        })
                        .Where(x => x.SourceAssId != 0 && x.SourceAssId != target.Id) // Ensure valid source and not stealing from self
                        .Where(x => {
                            var sourceAss = allAssignments.First(a => a.Id == x.SourceAssId);
                            return currentTracking[x.SourceAssId].Count > sourceAss.MinMalshabs;
                        })
                        .ToList();

                    foreach (var candidate in candidatesToSteal)
                    {
                        if (currentCount >= target.MinMalshabs) break;

                        // Explicitly remove from old list and add to new to prevent duplication
                        var malInSource = currentTracking[candidate.SourceAssId].FirstOrDefault(m => m.Id == candidate.Malshab.Id);
                        if (malInSource != null)
                        {
                            currentTracking[candidate.SourceAssId].Remove(malInSource);
                            currentTracking[target.Id].Add(malInSource);
                            currentCount++;
                        }
                    }
                }
            }

            // 6. Fill REMAINING Malshabs (Fix Bug 2: Go above minimum)
            // Now that everyone has met their minimum (or tried to), distribute leftovers
            var remainingMalshabs = allMalshabs.Where(m => !globalAssignedIds.Contains(m.Id)).ToList();
            foreach (var m in remainingMalshabs)
            {
                // Find assignments this person qualifies for
                var validAssignments = allAssignments.Where(ass =>
                    m.Dapar >= ass.DaparNeeded &&
                    m.Profile >= ass.ProfileNeeded &&
                    allRequirements.Where(r => r.AssignmentId == ass.Id)
                        .All(req => m.MalAbis.Any(ma => ma.AbilityId == req.AbilityId && ma.AbiLevel >= req.AbiLevel))
                ).ToList();

                if (validAssignments.Any())
                {
                    // Assign to the one with the fewest people currently to balance the load
                    var bestFit = validAssignments.OrderBy(a => currentTracking[a.Id].Count).First();
                    currentTracking[bestFit.Id].Add(m);
                    globalAssignedIds.Add(m.Id);
                }
            }

            // 7. Check for Failures (Requirement #2)
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
                TempData["SuccessMessage"] = "Auto-assignment completed successfully for all units.";
            }

            // 8. Save to Database
            _context.MalAss.RemoveRange(_context.MalAss);
            await _context.SaveChangesAsync();

            foreach (var kvp in currentTracking)
            {
                foreach (var malshab in kvp.Value)
                {
                    _context.MalAss.Add(new MalAss { MalshabId = malshab.Id, AssignmentId = kvp.Key });
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalAssExists(int id) => _context.MalAss.Any(e => e.Id == id);
    }
}