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

        // GET: MalAsses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MalAss.Include(m => m.assignment).Include(m => m.malshab);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MalAsses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malAss = await _context.MalAss
                .Include(m => m.assignment)
                .Include(m => m.malshab)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malAss == null)
            {
                return NotFound();
            }

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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MalshabId,AssignmentId")] MalAss malAss)
        {
            if (ModelState.IsValid)
            {
                var malshab = await _context.Malshabs.FindAsync(malAss.MalshabId);
                var assignment = await _context.Assignments.FindAsync(malAss.MalshabId);
                if (malshab != null)
                {
                    malshab.IsAssingned = true;
                    _context.Update(malshab);
                }
                if (assignment != null)
                {
                    assignment.CurrMalAssinged=assignment.CurrMalAssinged+1;
                    if (assignment.CurrMalAssinged >= assignment.MinMalshabs)
                    {
                        assignment.IsAboveMin = true;
                    }
                    _context.Update(assignment);
                }
                _context.Add(malAss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name", malAss.AssignmentId);
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name", malAss.MalshabId);
            return View(malAss);
        }

        // GET: MalAsses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malAss = await _context.MalAss.FindAsync(id);
            if (malAss == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name", malAss.AssignmentId);
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name", malAss.MalshabId);
            return View(malAss);
        }

        // POST: MalAsses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MalshabId,AssignmentId")] MalAss malAss)
        {
            if (id != malAss.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(malAss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalAssExists(malAss.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name", malAss.AssignmentId);
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name", malAss.MalshabId);
            return View(malAss);
        }

        // GET: MalAsses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malAss = await _context.MalAss
                .Include(m => m.assignment)
                .Include(m => m.malshab)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malAss == null)
            {
                return NotFound();
            }

            return View(malAss);
        }

        // POST: MalAsses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var malAss = await _context.MalAss.FindAsync(id);
            if (malAss != null)
            {
                _context.MalAss.Remove(malAss);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalAssExists(int id)
        {
            return _context.MalAss.Any(e => e.Id == id);
        }
    }
}
