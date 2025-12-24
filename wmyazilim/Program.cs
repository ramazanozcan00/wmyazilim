using Microsoft.AspNetCore.Authentication.Cookies; // Cookie için gerekli
using Microsoft.EntityFrameworkCore;
using wmyazilim.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný Servisi
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// 2. Authentication (Giriþ) Servisi - [Session'dan önce eklenmesi önerilir]
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Account/Login"; // Giriþ yapmamýþ kullanýcýyý buraya at
        options.AccessDeniedPath = "/Admin/Account/Login"; // Yetkisiz giriþte buraya at
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // 60 dk sonra oturum düþer
        options.SlidingExpiration = true; // Kullanýcý aktiftse süreyi uzat
    });

// 3. Session (Oturum/Sepet) Servisi
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // 30 dk hareketsiz kalýrsa sepet silinir
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 4. Controller ve View Servisleri
builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- HTTP REQUEST PIPELINE (Sýralama Çok Önemli) ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Statik dosyalar
app.UseStaticFiles(); // Eðer wwwroot kullanýyorsan bunu eklemelisin (Bootstrap/CSS için)

app.UseRouting();

app.UseSession(); // Session Middleware

// DÝKKAT: Önce Kimlik Doðrulama (Authentication), Sonra Yetkilendirme (Authorization)
app.UseAuthentication();
app.UseAuthorization();

// .NET 8/9 Static Assets (Varsa)
app.MapStaticAssets();

// Rotalar
// 1. Admin Rotasý
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// 2. Standart Rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();