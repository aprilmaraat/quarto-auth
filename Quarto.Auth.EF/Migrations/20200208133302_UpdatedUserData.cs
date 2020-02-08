using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Auth.EF.Migrations
{
    public partial class UpdatedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "User.Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "User.Data",
                type: "varchar(255)",
                nullable: true);
        }
    }
}
