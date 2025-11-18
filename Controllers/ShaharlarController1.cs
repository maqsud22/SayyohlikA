using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SayyohlikA.Models;

namespace SayyohlikA.Controllers
{
    public class ShaharsController : Controller
    {
        private readonly MyDbContext _context;

        public ShaharsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Shahars
        public async Task<IActionResult> Index()
        {
            var shahars = await _context.Shaharlar
                .Include(s => s.Davlat)
                .ToListAsync();
            return View(shahars);
        }

        // GET: Shahars/Create
        public IActionResult Create()
        {
            ViewBag.Davlatlar = _context.Davlatlar.ToList();
            return View();
        }

        // POST: Shahars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shahar shahar)
        {
            if (ModelState.IsValid)
            {
                _context.Shaharlar.Add(shahar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Davlatlar = _context.Davlatlar.ToList();
            return View(shahar);
        }

        // GET: Shahars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var shahar = await _context.Shaharlar.FindAsync(id);
            if (shahar == null) return NotFound();

            ViewBag.Davlatlar = _context.Davlatlar.ToList();
            return View(shahar);
        }

        // POST: Shahars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Shahar shahar)
        {
            if (id != shahar.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shahar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Shaharlar.Any(e => e.Id == shahar.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Davlatlar = _context.Davlatlar.ToList();
            return View(shahar);
        }

        // GET: Shahars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var shahar = await _context.Shaharlar
                .Include(s => s.Davlat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shahar == null) return NotFound();

            return View(shahar);
        }

        // POST: Shahars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shahar = await _context.Shaharlar.FindAsync(id);
            if (shahar != null)
            {
                _context.Shaharlar.Remove(shahar);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

