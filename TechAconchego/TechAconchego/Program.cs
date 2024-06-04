using Microsoft.EntityFrameworkCore;
using TechAconchego.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=LAPTOP-P7F3S17M\\SQLEXPRESS;Database=BDTPPDS;Trusted_Connection=True;TrustServerCertificate=True");
});
// Add support for session
builder.Services.AddSession();


// Add distributed memory cache
builder.Services.AddDistributedMemoryCache();

// Register IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Add session middleware
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
