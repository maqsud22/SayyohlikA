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

        // 📌 Loglarni ko'rsatish sahifasi
        public async Task<IActionResult> RequestLogs()
        {
            var logs = await _context.RequestLogs
                .OrderByDescending(l => l.Time)
                .ToListAsync();

            return View(logs);
        }

        // 📌 GPS ko‘rinadigan DTO
        public class GpsDto
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        // 📌 GPS ma'lumotlarini qabul qilib logga yozish
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SaveGpsLocation([FromBody] GpsDto data)
        {
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                var userAgent = Request.Headers["User-Agent"].ToString();

                var log = new RequestLog
                {
                    IP = ip,
                    Url = "GPS",
                    UserAgent = userAgent,
                    Device = userAgent.Contains("Mobile") ? "Mobile" :
                             userAgent.Contains("Tablet") ? "Tablet" : "Desktop",
                    Language = Request.Headers["Accept-Language"].ToString(),
                    Referer = Request.Headers["Referer"].ToString(),
                    Time = DateTime.UtcNow,

                    Country = "GPS",
                    City = "GPS",
                    ISP = "GPS",
                    Coordinates = $"{data.Latitude},{data.Longitude}"
                };

                _context.RequestLogs.Add(log);
                await _context.SaveChangesAsync();

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
            }
        }
    }
}
