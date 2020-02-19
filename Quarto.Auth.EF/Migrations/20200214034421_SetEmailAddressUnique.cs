using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Auth.EF.Migrations
{
    public partial class SetEmailAddressUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP INDEX [User.Data].[IX_User.Data_EmailAddress];");

            migrationBuilder.CreateIndex(
                name: "IX_User.Data_EmailAddress",
                table: "User.Data",
                column: "EmailAddress",
                unique: true,
                filter: "[EmailAddress] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User.Data_EmailAddress",
                table: "User.Data");

            migrationBuilder.CreateIndex(
                name: "IX_User.Data_EmailAddress",
                table: "User.Data",
                column: "EmailAddress");
        }
    }
}
