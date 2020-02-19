using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Auth.EF.Migrations
{
    public partial class RemoveUserDataUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "User.Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "User.Data",
                type: "varchar(255)",
                nullable: true);
        }
    }
}
