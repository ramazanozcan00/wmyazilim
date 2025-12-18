
using Microsoft.EntityFrameworkCore; // Bu namespace'i en üste ekleyin
using wmyazilim.Data;                // Bu namespace'i en üste ekleyin

var builder = WebApplication.CreateBuilder(args);

// Veritabaný servisini ekleyin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


// Session servislerini ekle
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // 30 dk hareketsiz kalýrsa sepet silinir
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});




// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession(); 
app.UseAuthorization();

app.MapStaticAssets();
// Admin Paneli Rotasý
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
