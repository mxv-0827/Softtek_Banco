using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class ConvertionEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrenciesConvertions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From_Currency = table.Column<int>(type: "int", nullable: false),
                    To_Currency = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrenciesConvertions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CurrenciesConvertions_Currencies_From_Currency",
                        column: x => x.From_Currency,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CurrenciesConvertions_Currencies_To_Currency",
                        column: x => x.To_Currency,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrenciesConvertions_From_Currency",
                table: "CurrenciesConvertions",
                column: "From_Currency");

            migrationBuilder.CreateIndex(
                name: "IX_CurrenciesConvertions_To_Currency",
                table: "CurrenciesConvertions",
                column: "To_Currency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrenciesConvertions");
        }
    }
}
