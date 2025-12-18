// Konum: wmyazilim/Models/Product.cs
namespace wmyazilim.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }       // Ürün Başlığı (Örn: Muhasebe Yazılımı)
        public string Description { get; set; } // Kısa Açıklama
        public decimal Price { get; set; }      // Fiyat
        public string ImageUrl { get; set; }    // Ürün Resmi Yolu
    }
}