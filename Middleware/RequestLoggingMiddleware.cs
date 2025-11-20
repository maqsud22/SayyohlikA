using Microsoft.AspNetCore.Http;
using SayyohlikA.Models;
using Microsoft.EntityFrameworkCore;
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

            // TO‘G‘RI IP olish
            string realIp = GetClientIp(context);

            var log = new RequestLog
            {
                IP = realIp,
                Url = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}",
                UserAgent = request.Headers["User-Agent"].ToString(),
                Device = GetDeviceType(request.Headers["User-Agent"].ToString()),
                Language = request.Headers["Accept-Language"].ToString(),
                Referer = request.Headers["Referer"].ToString(),
                Time = DateTime.UtcNow,

                Country = "Unknown",
                City = "Unknown",
                ISP = "Unknown",
                Coordinates = "Unknown"
            };

            // 🔥 GEO INFO olish
            if (!string.IsNullOrEmpty(realIp))
            {
                try
                {
                    var httpClient = new HttpClient();
                    var geo = await httpClient.GetFromJsonAsync<GeoResponse>($"http://ip-api.com/json/{realIp}");

                    if (geo != null)
                    {
                        log.Country = geo.Country ?? "Unknown";
                        log.City = geo.City ?? "Unknown";
                        log.ISP = geo.Isp ?? "Unknown";
                        log.Coordinates = $"{geo.Lat},{geo.Lon}";
                    }
                }
                catch { }
            }

            db.RequestLogs.Add(log);
            await db.SaveChangesAsync();

            await _next(context);
        }

        private string GetClientIp(HttpContext context)
        {
            string ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            if (string.IsNullOrEmpty(ip))
                ip = context.Connection.RemoteIpAddress?.ToString();

            if (!string.IsNullOrEmpty(ip) && ip.Contains(","))
                ip = ip.Split(',')[0].Trim();

            return ip;
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
            public string Isp { get; set; }
            public float Lat { get; set; }
            public float Lon { get; set; }
        }
    }
}
