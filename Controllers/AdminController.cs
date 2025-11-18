using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SayyohlikA.Models;

namespace SayyohlikA.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }

        // Loglarni ko'rsatish sahifasi
        public async Task<IActionResult> RequestLogs()
        {
            var logs = await _context.RequestLogs
                .OrderByDescending(l => l.Time)
                .ToListAsync();

            return View(logs);
        }
    }
}
