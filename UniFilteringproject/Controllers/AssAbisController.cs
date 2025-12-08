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
    public class AssAbisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssAbisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssAbis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssAbi.Include(a => a.ability).Include(a => a.assignment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssAbis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assAbi = await _context.AssAbi
                .Include(a => a.ability)
                .Include(a => a.assignment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assAbi == null)
            {
                return NotFound();
            }

            return View(assAbi);
        }

        // GET: AssAbis/Create
        public IActionResult Create()
        {
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name");
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name");
            return View();
        }

        // POST: AssAbis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssignmentId,AbilityId,AbiLevel")] AssAbi assAbi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assAbi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", assAbi.AbilityId);
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name", assAbi.AssignmentId);
            return View(assAbi);
        }

        // GET: AssAbis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assAbi = await _context.AssAbi.FindAsync(id);
            if (assAbi == null)
            {
                return NotFound();
            }
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", assAbi.AbilityId);
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name", assAbi.AssignmentId);
            return View(assAbi);
        }

        // POST: AssAbis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignmentId,AbilityId,AbiLevel")] AssAbi assAbi)
        {
            if (id != assAbi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assAbi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssAbiExists(assAbi.Id))
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
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", assAbi.AbilityId);
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "Id", "Name", assAbi.AssignmentId);
            return View(assAbi);
        }

        // GET: AssAbis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assAbi = await _context.AssAbi
                .Include(a => a.ability)
                .Include(a => a.assignment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assAbi == null)
            {
                return NotFound();
            }

            return View(assAbi);
        }

        // POST: AssAbis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assAbi = await _context.AssAbi.FindAsync(id);
            if (assAbi != null)
            {
                _context.AssAbi.Remove(assAbi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssAbiExists(int id)
        {
            return _context.AssAbi.Any(e => e.Id == id);
        }
    }
}
