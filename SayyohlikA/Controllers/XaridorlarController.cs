using Microsoft.AspNetCore.Mvc;
using SayyohlikA.Models;
using System.Collections.Generic;
using System.Linq;

namespace SayyohlikA.Controllers
{
    public class XaridorlarController : Controller
    {
        private readonly MyDbContext _context;

        public XaridorlarController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Xaridorlar.ToList());
        }

        public IActionResult AddXaridor()
        {
            ViewBag.SayohatManzillar = GetSayohatManzillar();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddXaridor(Xaridor xaridor)
        {
            if (ModelState.IsValid)
            {
                _context.Xaridorlar.Add(xaridor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.SayohatManzillar = GetSayohatManzillar();
            return View(xaridor);
        }

        public IActionResult Edit(int id)
        {
            var xaridor = _context.Xaridorlar.FirstOrDefault(x => x.Id == id);
            if (xaridor == null) return NotFound();

            ViewBag.SayohatManzillar = GetSayohatManzillar();
            return View(xaridor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Xaridor xaridor)
        {
            if (ModelState.IsValid)
            {
                _context.Xaridorlar.Update(xaridor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.SayohatManzillar = GetSayohatManzillar();
            return View(xaridor);
        }

        public IActionResult Delete(int id)
        {
            var xaridor = _context.Xaridorlar.Find(id);
            if (xaridor == null) return NotFound();
            return View(xaridor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var xaridor = _context.Xaridorlar.Find(id);
            _context.Xaridorlar.Remove(xaridor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private List<string> GetSayohatManzillar()
        {
            return new List<string> { "Fransiya", "Turkiya", "Shvetsariya", "Italiya" };
        }
    }
}