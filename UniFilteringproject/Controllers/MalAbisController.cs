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
    [Authorize(Roles = "Admin,Moderator,DataInputer")]
    public class MalAbisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MalAbisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MalAbis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MalAbi.Include(m => m.ability).Include(m => m.malshab);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MalAbis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malAbi = await _context.MalAbi
                .Include(m => m.ability)
                .Include(m => m.malshab)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malAbi == null)
            {
                return NotFound();
            }

            return View(malAbi);
        }

        // GET: MalAbis/Create
        public IActionResult Create()
        {
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name");
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name");
            return View();
        }

        // POST: MalAbis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MalshabId,AbilityId,AbiLevel")] MalAbi malAbi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(malAbi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", malAbi.AbilityId);
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name", malAbi.MalshabId);
            return View(malAbi);
        }

        // GET: MalAbis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malAbi = await _context.MalAbi.FindAsync(id);
            if (malAbi == null)
            {
                return NotFound();
            }
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", malAbi.AbilityId);
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name", malAbi.MalshabId);
            return View(malAbi);
        }

        // POST: MalAbis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MalshabId,AbilityId,AbiLevel")] MalAbi malAbi)
        {
            if (id != malAbi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(malAbi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalAbiExists(malAbi.Id))
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
            ViewData["AbilityId"] = new SelectList(_context.Abilities, "Id", "Name", malAbi.AbilityId);
            ViewData["MalshabId"] = new SelectList(_context.Malshabs, "Id", "Name", malAbi.MalshabId);
            return View(malAbi);
        }

        // GET: MalAbis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malAbi = await _context.MalAbi
                .Include(m => m.ability)
                .Include(m => m.malshab)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malAbi == null)
            {
                return NotFound();
            }

            return View(malAbi);
        }

        // POST: MalAbis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var malAbi = await _context.MalAbi.FindAsync(id);
            if (malAbi != null)
            {
                _context.MalAbi.Remove(malAbi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalAbiExists(int id)
        {
            return _context.MalAbi.Any(e => e.Id == id);
        }
    }
}
