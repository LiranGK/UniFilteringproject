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
    public class CorAbisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CorAbisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CorAbis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CorAbi.Include(c => c.ability).Include(c => c.corp);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CorAbis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corAbi = await _context.CorAbi
                .Include(c => c.ability)
                .Include(c => c.corp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corAbi == null)
            {
                return NotFound();
            }

            return View(corAbi);
        }

        // GET: CorAbis/Create
        public IActionResult Create()
        {
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name");
            ViewData["CorpId"] = new SelectList(_context.Corps, "Id", "Id");
            return View();
        }

        // POST: CorAbis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CorpId,AbilityId,AbiLevel")] CorAbi corAbi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corAbi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", corAbi.AbilityId);
            ViewData["CorpId"] = new SelectList(_context.Corps, "Id", "Id", corAbi.CorpId);
            return View(corAbi);
        }

        // GET: CorAbis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corAbi = await _context.CorAbi.FindAsync(id);
            if (corAbi == null)
            {
                return NotFound();
            }
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", corAbi.AbilityId);
            ViewData["CorpId"] = new SelectList(_context.Corps, "Id", "Id", corAbi.CorpId);
            return View(corAbi);
        }

        // POST: CorAbis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CorpId,AbilityId,AbiLevel")] CorAbi corAbi)
        {
            if (id != corAbi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corAbi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorAbiExists(corAbi.Id))
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
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", corAbi.AbilityId);
            ViewData["CorpId"] = new SelectList(_context.Corps, "Id", "Id", corAbi.CorpId);
            return View(corAbi);
        }

        // GET: CorAbis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corAbi = await _context.CorAbi
                .Include(c => c.ability)
                .Include(c => c.corp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corAbi == null)
            {
                return NotFound();
            }

            return View(corAbi);
        }

        // POST: CorAbis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corAbi = await _context.CorAbi.FindAsync(id);
            if (corAbi != null)
            {
                _context.CorAbi.Remove(corAbi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorAbiExists(int id)
        {
            return _context.CorAbi.Any(e => e.Id == id);
        }
    }
}
