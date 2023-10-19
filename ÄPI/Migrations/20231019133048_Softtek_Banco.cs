using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class Softtek_Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    DNI = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    Genre = table.Column<string>(type: "VARCHAR(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.DNI);
                });

            migrationBuilder.CreateTable(
                name: "AccountType_Currencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeID = table.Column<int>(type: "int", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType_Currencies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountType_Currencies_AccountTypes_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "AccountTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountType_Currencies_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDNI = table.Column<int>(type: "int", nullable: false),
                    Alias = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    AccountTypeID = table.Column<int>(type: "int", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    CBU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UUID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "AccountTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserDNI",
                        column: x => x.UserDNI,
                        principalTable: "Users",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    UserDNI = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(75)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.UserDNI);
                    table.ForeignKey(
                        name: "FK_Credentials_Users_UserDNI",
                        column: x => x.UserDNI,
                        principalTable: "Users",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceAccount = table.Column<int>(type: "int", nullable: true),
                    DestinationAccount = table.Column<int>(type: "int", nullable: true),
                    TransactionType = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_DestinationAccount",
                        column: x => x.DestinationAccount,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_SourceAccount",
                        column: x => x.SourceAccount,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Fiduciary" },
                    { 2, "Cryptocurrency" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Pesos" },
                    { 2, "Dollar" },
                    { 3, "Bitcoin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "DNI", "DateOfBirth", "Fullname", "Genre" },
                values: new object[,]
                {
                    { 40898968, new DateTime(1966, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gerardo Viand", "Masculino" },
                    { 44380182, new DateTime(2002, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maximo Viand", "Masculino" }
                });

            migrationBuilder.InsertData(
                table: "AccountType_Currencies",
                columns: new[] { "ID", "AccountTypeID", "CurrencyID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "AccountTypeID", "Alias", "Balance", "CBU", "CurrencyID", "UUID", "UserDNI" },
                values: new object[,]
                {
                    { 12345, 1, "Cuenta Ahorro Pesos", 0, "1234-5-6789-1111111111111", 1, null, 44380182 },
                    { 54321, 2, "Cuenta BTC", 0, null, 3, "A1B2C3D4-E5F6-G8H9-I110-J11K12L13M14", 44380182 },
                    { 67891, 1, "Cuenta Ahorro Dolares", 0, "1234-5-6789-2222222222222", 2, null, 44380182 },
                    { 78432, 2, "Mi bitcoin", 0, null, 3, "D1C2B3A4-F5E6-H8G9-110I-M11L12K13J14", 40898968 },
                    { 78645, 1, "Mis pesitos", 0, "4321-3-9876-3333333333333", 1, null, 40898968 }
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "UserDNI", "Email", "Password" },
                values: new object[,]
                {
                    { 40898968, "gerardviand@gmail.com", "4321" },
                    { 44380182, "maxiviand@gmail.com", "1234" }
                });

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
                name: "IX_Accounts_AccountTypeID",
                table: "Accounts",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CBU",
                table: "Accounts",
                column: "CBU",
                unique: true,
                filter: "[CBU] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyID",
                table: "Accounts",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserDNI",
                table: "Accounts",
                column: "UserDNI");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UUID",
                table: "Accounts",
                column: "UUID",
                unique: true,
                filter: "[UUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_Currencies_AccountTypeID",
                table: "AccountType_Currencies",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_Currencies_CurrencyID",
                table: "AccountType_Currencies",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_Email",
                table: "Credentials",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyID",
                table: "Transactions",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationAccount",
                table: "Transactions",
                column: "DestinationAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceAccount",
                table: "Transactions",
                column: "SourceAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountType_Currencies");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
