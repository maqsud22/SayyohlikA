using Microsoft.AspNetCore.Mvc;
using SayyohlikA.Models;
using Microsoft.EntityFrameworkCore;
namespace SayyohlikA.Controllers
{
    public class DavlatlarController : Controller
    {
        private readonly MyDbContext _context;

        public DavlatlarController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Davlatlar.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Davlat davlat)
        {
            if (ModelState.IsValid)
            {
                _context.Davlatlar.Add(davlat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(davlat);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var davlat = await _context.Davlatlar.FindAsync(id);
            if (davlat == null) return NotFound();
            return View(davlat);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Davlat davlat)
        {
            if (ModelState.IsValid)
            {
                _context.Update(davlat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(davlat);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var davlat = await _context.Davlatlar.FindAsync(id);
            if (davlat == null) return NotFound();

            _context.Davlatlar.Remove(davlat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddDavlat()
        {
            return View();  // Bu yerda faqat viewni chaqiryapmiz, hech qanday ma'lumot olish shart emas.
        }

        [HttpPost]
        public async Task<IActionResult> AddDavlat(Davlat davlat)
        {
            if (ModelState.IsValid)
            {
                _context.Davlatlar.Add(davlat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(davlat);
        }
    }

}
