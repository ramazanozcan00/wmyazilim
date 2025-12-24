using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wmyazilim.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductPricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceYearly",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Features", "IsPopular", "PriceYearly" },
                values: new object[] { "", false, 0m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Features", "IsPopular", "PriceYearly" },
                values: new object[] { "", false, 0m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Features", "IsPopular", "PriceYearly" },
                values: new object[] { "", false, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Features",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PriceYearly",
                table: "Products");
        }
    }
}
