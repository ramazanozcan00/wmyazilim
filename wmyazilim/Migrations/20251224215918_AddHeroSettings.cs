using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wmyazilim.Migrations
{
    /// <inheritdoc />
    public partial class AddHeroSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Button1Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Button1Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Button2Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Button2Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSetting", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HeroSetting",
                columns: new[] { "Id", "Button1Text", "Button1Url", "Button2Text", "Button2Url", "HeroImageUrl", "MainTitle", "SubDescription" },
                values: new object[] { 1, "Ücretsiz Başla", "/Home/DemoRequest", "Ürünleri Keşfet", "#products", "https://images.unsplash.com/photo-1551288049-bebda4e38f71?auto=format&fit=crop&q=80", "İşinizi Dijital Zekayla Büyütün", "WMYazılım ile süreçleri otomatiğe bağlayın." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroSetting");
        }
    }
}
