using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class PasswordEncryption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credentials",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "6d57ea0e81183fa3650fa1daa22a681125cd0fc3ff6ba2b1a351153f0f5980b0");

            migrationBuilder.UpdateData(
                table: "Credentials",
                keyColumn: "UserID",
                keyValue: 2,
                column: "Password",
                value: "bb033c213cf9f85b975a595aa919cde5dad931fef91cdfd598e27a27ff6185b2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credentials",
                keyColumn: "UserID",
                keyValue: 1,
                column: "Password",
                value: "1234");

            migrationBuilder.UpdateData(
                table: "Credentials",
                keyColumn: "UserID",
                keyValue: 2,
                column: "Password",
                value: "4321");
        }
    }
}
