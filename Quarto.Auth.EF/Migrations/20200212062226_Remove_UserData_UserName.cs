using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Auth.EF.Migrations
{
    public partial class Remove_UserData_UserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User.Data_UserName",
                table: "User.Data");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User.Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User.Data",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User.Data_UserName",
                table: "User.Data",
                column: "UserName");
        }
    }
}
