using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class UpdatedTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_DestinationAccount",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_SourceAccount",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Currencies_CurrencyID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DestinationAccount",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SourceAccount",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DestinationAccount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SourceAccount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "CurrencyID",
                table: "Transactions",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CurrencyID",
                table: "Transactions",
                newName: "IX_Transactions_AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Transactions",
                newName: "CurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                newName: "IX_Transactions_CurrencyID");

            migrationBuilder.AddColumn<int>(
                name: "DestinationAccount",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceAccount",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "Transactions",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "ID", "Amount", "CurrencyID", "DestinationAccount", "SourceAccount", "TransactionType" },
                values: new object[] { 1, 1000, 1, 67891, 12345, "Transfer" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "ID", "Amount", "CurrencyID", "DestinationAccount", "SourceAccount", "TransactionType" },
                values: new object[] { 2, 350, 2, 12345, null, "Deposit" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "ID", "Amount", "CurrencyID", "DestinationAccount", "SourceAccount", "TransactionType" },
                values: new object[] { 3, 700, 1, null, 78645, "Withdrawal" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationAccount",
                table: "Transactions",
                column: "DestinationAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceAccount",
                table: "Transactions",
                column: "SourceAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_DestinationAccount",
                table: "Transactions",
                column: "DestinationAccount",
                principalTable: "Accounts",
                principalColumn: "AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_SourceAccount",
                table: "Transactions",
                column: "SourceAccount",
                principalTable: "Accounts",
                principalColumn: "AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Currencies_CurrencyID",
                table: "Transactions",
                column: "CurrencyID",
                principalTable: "Currencies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
