using SayyohlikA.Models;
using Microsoft.EntityFrameworkCore;
using SayyohlikA.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ❌ DEFAULT config'larni O‘CHIRAMIZ
builder.Configuration.Sources.Clear();

// ✅ QO‘LDA config qo‘SHAMIZ (reload YO‘Q)
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddEnvironmentVariables();

// Connection string
var connectionString =
    Environment.GetEnvironmentVariable("DefaultConnection")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();

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

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
