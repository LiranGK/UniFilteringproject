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
            return View(await _context.Malshabs.ToListAsync());
        }

        public async Task<IActionResult> Viable(int assignmentId)
        {
            // Get all requirements for the assignment
            var requirements = await _context.AssAbi
                .Where(r => r.AssignmentId == assignmentId)
                .ToListAsync();

            var viableMalshabs = await _context.Malshabs
                .Include(m => m.MalAbis)
                .Where(m =>
                    requirements.All(req =>
                        m.MalAbis.Any(ma =>
                            ma.AbilityId == req.AbilityId &&
                            ma.AbiLevel >= req.AbiLevel)))
                .ToListAsync();

            return View(viableMalshabs);
        }

        // GET: Malshabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malshab = await _context.Malshabs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malshab == null)
            {
                return NotFound();
            }

            return View(malshab);
        }

        // GET: Malshabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Malshabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            if (id == null)
            {
                return NotFound();
            }

            var malshab = await _context.Malshabs.FindAsync(id);
            if (malshab == null)
            {
                return NotFound();
            }
            return View(malshab);
        }

        // POST: Malshabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Dapar,Profile")] Malshab malshab)
        {
            if (id != malshab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(malshab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalshabExists(malshab.Id))
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
            return View(malshab);
        }

        // GET: Malshabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malshab = await _context.Malshabs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malshab == null)
            {
                return NotFound();
            }

            return View(malshab);
        }

        // POST: Malshabs/Delete/5
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
