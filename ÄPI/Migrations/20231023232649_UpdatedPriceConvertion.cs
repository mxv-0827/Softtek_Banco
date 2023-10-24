using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class UpdatedPriceConvertion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CurrenciesConvertions",
                type: "DECIMAL(18,10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)");

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 2,
                column: "Price",
                value: 0.00000008633009m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 3,
                column: "Price",
                value: 349.99061m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 4,
                column: "Price",
                value: 0.00003021957m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 5,
                column: "Price",
                value: 11581590m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 6,
                column: "Price",
                value: 33091.14m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CurrenciesConvertions",
                type: "DECIMAL(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,10)");

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 2,
                column: "Price",
                value: 0.00000008690976m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 3,
                column: "Price",
                value: 349.90775m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 4,
                column: "Price",
                value: 0.00003042854m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 5,
                column: "Price",
                value: 11499330m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 6,
                column: "Price",
                value: 32845.69m);
        }
    }
}
