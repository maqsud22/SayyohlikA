using SayyohlikA.Models;
using Microsoft.EntityFrameworkCore;
using SayyohlikA.Middleware;

var builder = WebApplication.CreateBuilder(args);

// appsettings.json faylini monitoringsiz yuklash
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

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

// Middleware eng to‘g‘ri joyi shu — routingdan keyin, authorizationdan oldin
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
