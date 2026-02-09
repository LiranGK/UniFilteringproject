using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniFilteringproject.Data;
using UniFilteringproject.Models;

namespace UniFilteringproject.Controllers
{
    [Authorize(Roles = "Admin,DataInputer")]
    public class MalshabsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MalshabsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Malshabs
        public async Task<IActionResult> Index()
        {
            // Fix: Added Include so the calculated property 'IsAssigned' works on the list page
            return View(await _context.Malshabs
                .Include(m => m.MalAssignedList)
                .ToListAsync());
        }

        // GET: Malshabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            // FIX: Added .Include(m => m.MalAssignedList) and .ThenInclude(ma => ma.Assignment)
            // This allows the "IsAssigned" check and the unit name display to work.
            var malshab = await _context.Malshabs
                .Include(m => m.MalAbis)
                    .ThenInclude(ma => ma.ability)
                .Include(m => m.MalAssignedList)
                    .ThenInclude(ma => ma.Assignment)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (malshab == null) return NotFound();

            // Load data for the blocking interface
            ViewBag.Assignments = await _context.Assignments.ToListAsync();
            ViewBag.BlockedAssignmentIds = await _context.MalBlocks
                .Where(b => b.MalshabId == id)
                .Select(b => b.AssignmentId)
                .ToListAsync();

            return View(malshab);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleBlock(int malshabId, int assignmentId)
        {
            if (malshabId <= 0 || assignmentId <= 0) return BadRequest();

            var existing = await _context.MalBlocks
                .FirstOrDefaultAsync(b => b.MalshabId == malshabId && b.AssignmentId == assignmentId);

            if (existing != null) _context.MalBlocks.Remove(existing);
            else _context.MalBlocks.Add(new MalBlock { MalshabId = malshabId, AssignmentId = assignmentId });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = malshabId });
        }

        // GET: Malshabs/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Dapar,Profile")] Malshab malshab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(malshab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(malshab);
        }

        // GET: Malshabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var malshab = await _context.Malshabs.FindAsync(id);
            if (malshab == null) return NotFound();

            return View(malshab);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Dapar,Profile")] Malshab malshab)
        {
            if (id != malshab.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(malshab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalshabExists(malshab.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(malshab);
        }

        // GET: Malshabs/Viable/5
        [HttpGet("Malshabs/Viable/{id}")]
        public async Task<IActionResult> Viable(int id)
        {
            // We fetch the Name along with the requirements
            var assignment = await _context.Assignments
                .Where(a => a.Id == id)
                .Select(a => new { a.Name, a.DaparNeeded, a.ProfileNeeded })
                .SingleOrDefaultAsync();

            if (assignment == null) return NotFound();

            // Store the name in ViewData so you can use it in the View's title: @ViewData["AssignmentName"]
            ViewData["AssignmentName"] = assignment.Name;

            var viableMalshabs = await _context.Malshabs
                .Include(m => m.MalAbis)
                .Include(m => m.MalAssignedList)
                .Where(m =>
                    m.Dapar >= assignment.DaparNeeded &&
                    m.Profile >= assignment.ProfileNeeded &&
                    !_context.AssAbi
                        .Where(r => r.AssignmentId == id)
                        .Any(req =>
                            !m.MalAbis.Any(ma =>
                                ma.AbilityId == req.AbilityId &&
                                ma.AbiLevel >= req.AbiLevel)))
                .ToListAsync();

            return View(viableMalshabs);
        }

        // GET: Malshabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            // Fix: Include assignments here so the user knows what they are removing the Malshab from
            var malshab = await _context.Malshabs
                .Include(m => m.MalAssignedList)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (malshab == null) return NotFound();

            return View(malshab);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var malshab = await _context.Malshabs.FindAsync(id);
            if (malshab != null)
            {
                _context.Malshabs.Remove(malshab);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalshabExists(int id)
        {
            return _context.Malshabs.Any(e => e.Id == id);
        }
    }
}