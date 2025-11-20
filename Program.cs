using SayyohlikA.Models;
using Microsoft.EntityFrameworkCore;
using SayyohlikA.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Environment variable orqali connection stringni olish
var connectionString = Environment.GetEnvironmentVariable("DefaultConnection")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();

// EF Core uchun PostgreSQL ulanishi
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ?? MIDDLEWARENI ENG TO‘G‘RI JOYGA QO‘YISH ??
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
