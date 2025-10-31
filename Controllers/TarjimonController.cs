using Microsoft.AspNetCore.Mvc;
using SayyohlikA.Models;
using System.Linq;

namespace SayyohlikA.Controllers
{
    public class TarjimonController : Controller
    {
        private readonly MyDbContext _context;

        public TarjimonController(MyDbContext context)
        {
            _context = context;
        }

        // Tarjimonlar ro'yxati (Read)
        public IActionResult Index()
        {
            var tarjimonlar = _context.Tarjimonlar.ToList();
            return View(tarjimonlar);
        }

        // Yangi tarjimon qo'shish sahifasi (Create GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yangi tarjimon bazaga saqlash (Create POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tarjimon tarjimon)
        {
            if (ModelState.IsValid)
            {
                _context.Tarjimonlar.Add(tarjimon);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarjimon);
        }

        // Tarjimonni tahrirlash sahifasi (Edit GET)
        public IActionResult Edit(int id)
        {
            var tarjimon = _context.Tarjimonlar.FirstOrDefault(x => x.Id == id);
            if (tarjimon == null)
            {
                return NotFound();
            }
            return View(tarjimon);
        }

        // Tarjimonni yangilash (Edit POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tarjimon tarjimon)
        {
            if (ModelState.IsValid)
            {
                _context.Tarjimonlar.Update(tarjimon);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarjimon);
        }

        // Tarjimonni o'chirish sahifasi (Delete GET)
        public IActionResult Delete(int id)
        {
            var tarjimon = _context.Tarjimonlar.FirstOrDefault(x => x.Id == id);
            if (tarjimon == null)
            {
                return NotFound();
            }
            return View(tarjimon);
        }

        // Tarjimonni o'chirish (Delete POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tarjimon = _context.Tarjimonlar.FirstOrDefault(x => x.Id == id);
            if (tarjimon == null)
            {
                return NotFound();
            }

            _context.Tarjimonlar.Remove(tarjimon);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    


        public IActionResult AddTarjimon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTarjimon(Tarjimon model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Bazaga saqlash
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}


