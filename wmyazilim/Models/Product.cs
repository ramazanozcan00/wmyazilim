using System.ComponentModel.DataAnnotations;

namespace wmyazilim.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public string Slogan { get; set; } = string.Empty;

        // FİYATLANDIRMA
        public decimal Price { get; set; } // Bu AYLIK fiyat olsun
        public decimal PriceYearly { get; set; } // Bu YILLIK fiyat

        // ÖZELLİKLER (Maddeleri '|' işareti ile ayıracağız)
        public string Features { get; set; } = string.Empty;

        // Tasarımda öne çıkarmak için (Örn: "En Popüler")
        public bool IsPopular { get; set; } = false;
    }
}