using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class UpdatedConvertionSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CurrenciesConvertions",
                columns: new[] { "ID", "From_Currency", "Price", "To_Currency" },
                values: new object[,]
                {
                    { 1, 1, 0.00286m, 2 },
                    { 2, 1, 0.00000008690976m, 3 },
                    { 3, 2, 349.90775m, 1 },
                    { 4, 2, 0.00003042854m, 3 },
                    { 5, 3, 11499330m, 1 },
                    { 6, 3, 32845.69m, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
