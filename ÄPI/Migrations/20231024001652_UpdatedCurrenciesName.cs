using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class UpdatedCurrenciesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "ARS");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "USD");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "BTC");

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 2,
                column: "Price",
                value: 0.00000008661253m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 3,
                column: "Price",
                value: 349.8849m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 4,
                column: "Price",
                value: 0.00003030442m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 5,
                column: "Price",
                value: 11545670m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 6,
                column: "Price",
                value: 32998.49m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "Pesos");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Dollar");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Bitcoin");

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
    }
}
