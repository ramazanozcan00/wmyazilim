using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wmyazilim.Migrations
{
    /// <inheritdoc />
    public partial class AddProductSlogan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "HeaderMenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Title", "Url" },
                values: new object[] { "Fiyatlandırma", "/#pricing" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Features", "ImageUrl", "Price", "PriceYearly", "Slogan", "Title" },
                values: new object[] { "Küçük işletmeler ve startup'lar için ideal.", "Temel E-Ticaret Modülü|Sınırsız Ürün Ekleme|Standart SEO Desteği|E-posta Desteği", "", 499m, 4990m, "", "Başlangıç Paketi" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Features", "ImageUrl", "IsPopular", "Price", "PriceYearly", "Slogan", "Title" },
                values: new object[] { "Büyüyen işletmeler için tam kapsamlı çözüm.", "Gelişmiş E-Ticaret|Pazaryeri Entegrasyonu|Yapay Zeka SEO|7/24 Canlı Destek|Mobil Uygulama (Android)", "", true, 999m, 9990m, "Yıllık planda 2 ay hediye!", "Profesyonel Paket" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Features", "ImageUrl", "Price", "PriceYearly", "Slogan", "Title" },
                values: new object[] { "Kurumsal firmalar için özel altyapı.", "Özel Sunucu Altyapısı|Tüm Pazaryerleri|Global SEO Paketi|Özel Müşteri Temsilcisi|iOS ve Android Uygulama|Sınırsız API Erişimi", "", 1999m, 19990m, "%25 İndirim Fırsatı", "Enterprise" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "HeaderMenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Title", "Url" },
                values: new object[] { "Ürünler", "/#products" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Features", "ImageUrl", "Price", "PriceYearly", "Title" },
                values: new object[] { "Hızlı ve güvenli online satış altyapısı.", "", "https://placehold.co/600x400?text=E-Ticaret", 4999m, 0m, "WM E-Ticaret Paketi" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Features", "ImageUrl", "IsPopular", "Price", "PriceYearly", "Title" },
                values: new object[] { "Google sıralamanızı yükselten analiz aracı.", "", "https://placehold.co/600x400?text=SEO+Tool", false, 2499m, 0m, "Kurumsal SEO Yazılımı" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Features", "ImageUrl", "Price", "PriceYearly", "Title" },
                values: new object[] { "Sipariş ve stok takibi için profesyonel çözüm.", "", "https://placehold.co/600x400?text=Otomasyon", 3500m, 0m, "Restoran Otomasyonu" });
        }
    }
}
