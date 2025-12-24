using Microsoft.EntityFrameworkCore;
using wmyazilim.Models;

namespace wmyazilim.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<DemoRequest> DemoRequests { get; set; }
        public DbSet<HeaderMenuItem> HeaderMenuItems { get; set; }
        public DbSet<FooterSetting> FooterSettings { get; set; }
        public DbSet<HeroSetting> HeroSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ÜRÜNLERİ GÜNCELLİYORUZ
            modelBuilder.Entity<Product>().HasData(
                  new Product
                  {
                      Id = 1,
                      Title = "Başlangıç Paketi",
                      Description = "Küçük işletmeler ve startup'lar için ideal.",
                      Price = 499,
                      PriceYearly = 4990,
                      Slogan = "", // Boş
                      Features = "Temel E-Ticaret Modülü|Sınırsız Ürün Ekleme|Standart SEO Desteği|E-posta Desteği",
                      ImageUrl = "",
                      IsPopular = false
                  },
                  new Product
                  {
                      Id = 2,
                      Title = "Profesyonel Paket",
                      Description = "Büyüyen işletmeler için tam kapsamlı çözüm.",
                      Price = 999,
                      PriceYearly = 9990,
                      Slogan = "Yıllık planda 2 ay hediye!", // YENİ EKLENDİ
                      Features = "Gelişmiş E-Ticaret|Pazaryeri Entegrasyonu|Yapay Zeka SEO|7/24 Canlı Destek|Mobil Uygulama (Android)",
                      ImageUrl = "",
                      IsPopular = true
                  },
                  new Product
                  {
                      Id = 3,
                      Title = "Enterprise",
                      Description = "Kurumsal firmalar için özel altyapı.",
                      Price = 1999,
                      PriceYearly = 19990,
                      Slogan = "%25 İndirim Fırsatı", // Örnek
                      Features = "Özel Sunucu Altyapısı|Tüm Pazaryerleri|Global SEO Paketi|Özel Müşteri Temsilcisi|iOS ve Android Uygulama|Sınırsız API Erişimi",
                      ImageUrl = "",
                      IsPopular = false
                  }
              );

            // ... Diğer Seed Data'lar (Menu, Footer, Hero) aynı kalabilir ...
            modelBuilder.Entity<HeaderMenuItem>().HasData(
                new HeaderMenuItem { Id = 1, Title = "Anasayfa", Url = "/", Order = 1, IsActive = true },
                new HeaderMenuItem { Id = 2, Title = "Fiyatlandırma", Url = "/#pricing", Order = 2, IsActive = true }, // Linki güncelledim
                new HeaderMenuItem { Id = 3, Title = "Özellikler", Url = "/#features", Order = 3, IsActive = true },
                new HeaderMenuItem { Id = 4, Title = "İletişim", Url = "/Home/Contact", Order = 4, IsActive = true }
            );

            modelBuilder.Entity<FooterSetting>().HasData(new FooterSetting { Id = 1 });
            modelBuilder.Entity<HeroSetting>().HasData(new HeroSetting { Id = 1 });
        }
    }
}