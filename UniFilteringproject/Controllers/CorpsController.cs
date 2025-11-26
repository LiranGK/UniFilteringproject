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
    public class CorpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CorpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Corps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Corps.ToListAsync());
        }

        // GET: Corps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corp = await _context.Corps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corp == null)
            {
                return NotFound();
            }

            return View(corp);
        }

        // GET: Corps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsFull,DoesBlock,MinMalshabs")] Corp corp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corp);
        }

        // GET: Corps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corp = await _context.Corps.FindAsync(id);
            if (corp == null)
            {
                return NotFound();
            }
            return View(corp);
        }

        // POST: Corps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsFull,DoesBlock,MinMalshabs")] Corp corp)
        {
            if (id != corp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorpExists(corp.Id))
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
            return View(corp);
        }

        // GET: Corps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corp = await _context.Corps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corp == null)
            {
                return NotFound();
            }

            return View(corp);
        }

        // POST: Corps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corp = await _context.Corps.FindAsync(id);
            if (corp != null)
            {
                _context.Corps.Remove(corp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorpExists(int id)
        {
            return _context.Corps.Any(e => e.Id == id);
        }
    }
}
