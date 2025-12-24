using System.ComponentModel.DataAnnotations;

namespace wmyazilim.Models
{
    // Üst Menü Linkleri İçin
    public class HeaderMenuItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur")]
        public string Title { get; set; } = string.Empty; // Örn: Anasayfa

        [Required(ErrorMessage = "Link zorunludur")]
        public string Url { get; set; } = string.Empty;   // Örn: /Home/Index veya #products

        public int Order { get; set; } // Sıralama (1, 2, 3...)
        public bool IsActive { get; set; } = true;
    }
    // ... Mevcut sınıfların altına ekle

    public class HeroSetting
    {
        
        public int Id { get; set; }
        public string BadgeText { get; set; } = "Yeni Sürüm Yayında";
        public string BadgeIcon { get; set; } = "bi-stars";
        // Sloganlar
        public string MainTitle { get; set; } = "İşinizi Dijital Zekayla Büyütün";
        public string SubDescription { get; set; } = "WMYazılım ile süreçleri otomatiğe bağlayın.";

        // Görsel
        public string HeroImageUrl { get; set; } = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?auto=format&fit=crop&q=80";

        // Buton 1 (Ana Buton)
        public string Button1Text { get; set; } = "Ücretsiz Başla";
        public string Button1Url { get; set; } = "/Home/DemoRequest";

        // Buton 2 (İkincil Buton)
        public string Button2Text { get; set; } = "Ürünleri Keşfet";
        public string Button2Url { get; set; } = "#products";
    }

    // Footer Ayarları İçin
    public class FooterSetting
    {
        public int Id { get; set; }
        public string Description { get; set; } = "İşletmenizi dijital dünyada bir adım öne taşıyın.";
        public string CopyrightText { get; set; } = "2025 WMYazılım";
        public string Email { get; set; } = "info@wmyazilim.com";
        public string PhoneNumber { get; set; } = "+90 555 000 0000";
        public string Address { get; set; } = "Teknopark İstanbul";
    }
}