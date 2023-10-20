using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ÄPI.Migrations
{
    public partial class UserPKModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserDNI",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_Users_UserDNI",
                table: "Credentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials");

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "UserDNI",
                keyColumnType: "int",
                keyValue: 40898968);

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "UserDNI",
                keyColumnType: "int",
                keyValue: 44380182);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "DNI",
                keyValue: 40898968);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "DNI",
                keyValue: 44380182);

            migrationBuilder.DropColumn(
                name: "UserDNI",
                table: "Credentials");

            migrationBuilder.RenameColumn(
                name: "UserDNI",
                table: "Accounts",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_UserDNI",
                table: "Accounts",
                newName: "IX_Accounts_UserID");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Credentials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DNI",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials",
                column: "UserID");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "DateOfBirth", "DNI", "Fullname", "Genre" },
                values: new object[] { 1, new DateTime(2002, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 44380182, "Maximo Viand", "Masculino" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "DateOfBirth", "DNI", "Fullname", "Genre" },
                values: new object[] { 2, new DateTime(1966, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 40898968, "Gerardo Viand", "Masculino" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 12345,
                column: "UserID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 54321,
                column: "UserID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 67891,
                column: "UserID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 78432,
                column: "UserID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 78645,
                column: "UserID",
                value: 2);

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "UserID", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "maxiviand@gmail.com", "1234" },
                    { 2, "gerardviand@gmail.com", "4321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DNI",
                table: "Users",
                column: "DNI",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserID",
                table: "Accounts",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_Users_UserID",
                table: "Credentials",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_Users_UserID",
                table: "Credentials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DNI",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials");

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "UserID",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "UserID",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Credentials");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Accounts",
                newName: "UserDNI");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_UserID",
                table: "Accounts",
                newName: "IX_Accounts_UserDNI");

            migrationBuilder.AlterColumn<int>(
                name: "DNI",
                table: "Users",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserDNI",
                table: "Credentials",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "DNI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Credentials",
                table: "Credentials",
                column: "UserDNI");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 12345,
                column: "UserDNI",
                value: 44380182);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 54321,
                column: "UserDNI",
                value: 44380182);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 67891,
                column: "UserDNI",
                value: 44380182);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 78432,
                column: "UserDNI",
                value: 40898968);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 78645,
                column: "UserDNI",
                value: 40898968);

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "UserDNI", "Email", "Password" },
                values: new object[,]
                {
                    { 40898968, "gerardviand@gmail.com", "4321" },
                    { 44380182, "maxiviand@gmail.com", "1234" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserDNI",
                table: "Accounts",
                column: "UserDNI",
                principalTable: "Users",
                principalColumn: "DNI",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_Users_UserDNI",
                table: "Credentials",
                column: "UserDNI",
                principalTable: "Users",
                principalColumn: "DNI",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
