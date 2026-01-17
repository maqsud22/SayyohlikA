using Microsoft.AspNetCore.Mvc;
using SayyohlikA.Models;
using Microsoft.EntityFrameworkCore;

namespace SayyohlikA.Controllers
{
    public class YangiliklarController : Controller
    {
        private readonly MyDbContext _context;

        public YangiliklarController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var yangiliklar = await _context.Yangiliklar
                .OrderByDescending(y => y.PublishedDate)
                .ToListAsync();
            return View(yangiliklar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Yangiliklar yangilik)
        {
            if (yangilik.PublishedDate == default)
            {
                yangilik.PublishedDate = DateTime.UtcNow;
            }

            if (ModelState.IsValid)
            {
                _context.Yangiliklar.Add(yangilik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yangilik);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var yangilik = await _context.Yangiliklar.FindAsync(id);
            if (yangilik == null) return NotFound();
            return View(yangilik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Yangiliklar yangilik)
        {
            if (yangilik.PublishedDate == default)
            {
                yangilik.PublishedDate = DateTime.UtcNow;
            }

            if (ModelState.IsValid)
            {
                _context.Yangiliklar.Update(yangilik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yangilik);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var yangilik = await _context.Yangiliklar.FindAsync(id);
            if (yangilik == null) return NotFound();
            return View(yangilik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yangilik = await _context.Yangiliklar.FindAsync(id);
            if (yangilik != null)
            {
                _context.Yangiliklar.Remove(yangilik);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddYangilik()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> AddYangilik(Yangiliklar yangilik)
        {
            return Create(yangilik);
        }
    }
}
