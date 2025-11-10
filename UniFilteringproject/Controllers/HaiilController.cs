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
    public class HaiilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HaiilController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Haiil
        public async Task<IActionResult> Index()
        {
            return View(await _context.TheHaiils.ToListAsync());
        }

        // GET: Haiil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haiil = await _context.TheHaiils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haiil == null)
            {
                return NotFound();
            }

            return View(haiil);
        }

        // GET: Haiil/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haiil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsFull")] Haiil haiil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haiil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haiil);
        }

        // GET: Haiil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haiil = await _context.TheHaiils.FindAsync(id);
            if (haiil == null)
            {
                return NotFound();
            }
            return View(haiil);
        }

        // POST: Haiil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsFull")] Haiil haiil)
        {
            if (id != haiil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haiil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaiilExists(haiil.Id))
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
            return View(haiil);
        }

        // GET: Haiil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haiil = await _context.TheHaiils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (haiil == null)
            {
                return NotFound();
            }

            return View(haiil);
        }

        // POST: Haiil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var haiil = await _context.TheHaiils.FindAsync(id);
            if (haiil != null)
            {
                _context.TheHaiils.Remove(haiil);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaiilExists(int id)
        {
            return _context.TheHaiils.Any(e => e.Id == id);
        }
    }
}
