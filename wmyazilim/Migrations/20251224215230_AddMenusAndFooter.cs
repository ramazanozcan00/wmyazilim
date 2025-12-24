using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wmyazilim.Migrations
{
    /// <inheritdoc />
    public partial class AddMenusAndFooter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FooterSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopyrightText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeaderMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderMenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FooterSettings",
                columns: new[] { "Id", "Address", "CopyrightText", "Description", "Email", "PhoneNumber" },
                values: new object[] { 1, "Teknopark İstanbul", "2025 WMYazılım", "İşletmenizi dijital dünyada bir adım öne taşıyın.", "info@wmyazilim.com", "+90 555 000 0000" });

            migrationBuilder.InsertData(
                table: "HeaderMenuItems",
                columns: new[] { "Id", "IsActive", "Order", "Title", "Url" },
                values: new object[,]
                {
                    { 1, true, 1, "Anasayfa", "/" },
                    { 2, true, 2, "Ürünler", "/#products" },
                    { 3, true, 3, "Özellikler", "/#features" },
                    { 4, true, 4, "İletişim", "/Home/Contact" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterSettings");

            migrationBuilder.DropTable(
                name: "HeaderMenuItems");
        }
    }
}
