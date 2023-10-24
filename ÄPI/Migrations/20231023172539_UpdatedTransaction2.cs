using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class UpdatedTransaction2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Transactions",
                type: "VARCHAR(40)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Transactions");
        }
    }
}
