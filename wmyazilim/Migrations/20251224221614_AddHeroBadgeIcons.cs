using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wmyazilim.Migrations
{
    /// <inheritdoc />
    public partial class AddHeroBadgeIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BadgeIcon",
                table: "HeroSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BadgeText",
                table: "HeroSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "HeroSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BadgeIcon", "BadgeText" },
                values: new object[] { "bi-stars", "Yeni Sürüm Yayında" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeIcon",
                table: "HeroSettings");

            migrationBuilder.DropColumn(
                name: "BadgeText",
                table: "HeroSettings");
        }
    }
}
