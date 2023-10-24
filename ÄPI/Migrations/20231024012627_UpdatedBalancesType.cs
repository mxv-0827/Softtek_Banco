using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class UpdatedBalancesType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "DECIMAL(18,10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Accounts",
                type: "DECIMAL(18,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 12345,
                column: "Balance",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 54321,
                column: "Balance",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 67891,
                column: "Balance",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 78432,
                column: "Balance",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 78645,
                column: "Balance",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 2,
                column: "Price",
                value: 0.00000008465883m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 3,
                column: "Price",
                value: 349.84207m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 4,
                column: "Price",
                value: 0.00002962053m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 5,
                column: "Price",
                value: 11810780m);

            migrationBuilder.UpdateData(
                table: "CurrenciesConvertions",
                keyColumn: "ID",
                keyValue: 6,
                column: "Price",
                value: 33759.98m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,10)");

            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,3)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 12345,
                column: "Balance",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 54321,
                column: "Balance",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 67891,
                column: "Balance",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 78432,
                column: "Balance",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 78645,
                column: "Balance",
                value: 0);

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
    }
}
