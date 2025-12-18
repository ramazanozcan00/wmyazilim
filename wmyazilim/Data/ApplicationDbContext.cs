using Microsoft.EntityFrameworkCore;
using wmyazilim.Models;

namespace wmyazilim.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Veritabanındaki 'Products' tablosunu temsil eder
        public DbSet<Product> Products { get; set; }

        // Veritabanı ilk oluşurken içine varsayılan veri ekleyelim (Seed Data)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "WM E-Ticaret Paketi", Description = "Hızlı ve güvenli online satış altyapısı.", Price = 4999, ImageUrl = "https://placehold.co/600x400?text=E-Ticaret" },
                new Product { Id = 2, Title = "Kurumsal SEO Yazılımı", Description = "Google sıralamanızı yükselten analiz aracı.", Price = 2499, ImageUrl = "https://placehold.co/600x400?text=SEO+Tool" },
                new Product { Id = 3, Title = "Restoran Otomasyonu", Description = "Sipariş ve stok takibi için profesyonel çözüm.", Price = 3500, ImageUrl = "https://placehold.co/600x400?text=Otomasyon" }
            );
        }
    }
}