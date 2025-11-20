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
    public class CorpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CorpController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Corp
        public async Task<IActionResult> IndexC()
        {
            return View(await _context.TheCorps.ToListAsync());
        }

        // GET: Corp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corp = await _context.TheCorps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corp == null)
            {
                return NotFound();
            }

            return View(corp);
        }

        // GET: Corp/Create
        public IActionResult CreateC()
        {
            return View();
        }

        // POST: Corp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateC([Bind("Id,IsFull")] Corp corp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexC));
            }
            return View(corp);
        }

        // GET: Corp/Edit/5
        public async Task<IActionResult> EditC(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corp = await _context.TheCorps.FindAsync(id);
            if (corp == null)
            {
                return NotFound();
            }
            return View(corp);
        }

        // POST: Haiil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditC(int id, [Bind("Id,IsFull")] Corp corp)
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
                    if (!HaiilExists(corp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexC));
            }
            return View(corp);
        }

        // GET: Corp/Delete/5
        public async Task<IActionResult> DeleteC(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corp = await _context.TheCorps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corp == null)
            {
                return NotFound();
            }
            
            return View(corp);
        }

        // POST: Corp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corp = await _context.TheCorps.FindAsync(id);
            if (corp != null)
            {
                _context.TheCorps.Remove(corp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexC));
        }

        private bool HaiilExists(int id)
        {
            return _context.TheCorps.Any(e => e.Id == id);
        }
    }
}
