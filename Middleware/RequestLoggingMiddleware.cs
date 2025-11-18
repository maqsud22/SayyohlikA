using Microsoft.AspNetCore.Http;
using SayyohlikA.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Http.Json;

namespace SayyohlikA.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, MyDbContext db)
        {
            var request = context.Request;

            var log = new RequestLog
            {
                IP = context.Connection.RemoteIpAddress?.ToString(),
                Url = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}",
                UserAgent = request.Headers["User-Agent"].ToString(),
                Device = GetDeviceType(request.Headers["User-Agent"].ToString()),
                Language = request.Headers["Accept-Language"].ToString(),
                Referer = request.Headers["Referer"].ToString(),
                Time = DateTime.UtcNow,

                // Default qiymatlarni qo‘shamiz
                Country = "Unknown",
                City = "Unknown",
                ISP = "Unknown",
                Coordinates = "Unknown"
            };

            // Optional: IP orqali taxminiy joylashuvni olish
            if (!string.IsNullOrEmpty(log.IP))
            {
                try
                {
                    var httpClient = new HttpClient();
                    var geo = await httpClient.GetFromJsonAsync<GeoResponse>($"http://ip-api.com/json/{log.IP}");
                    if (geo != null)
                    {
                        log.Country = geo.Country ?? "Unknown";
                        log.City = geo.City ?? "Unknown";
                        log.ISP = geo.ISP ?? "Unknown";
                        log.Coordinates = $"{geo.Lat},{geo.Lon}";
                    }
                }
                catch { /* Xatolarni e’tiborsiz qoldiramiz */ }
            }


            db.RequestLogs.Add(log);
            await db.SaveChangesAsync();

            await _next(context);
        }

        private string GetDeviceType(string userAgent)
        {
            if (userAgent.Contains("Mobile")) return "Mobile";
            if (userAgent.Contains("Tablet")) return "Tablet";
            return "Desktop";
        }

        private class GeoResponse
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string ISP { get; set; }
            public float Lat { get; set; }
            public float Lon { get; set; }
        }
    }
}
