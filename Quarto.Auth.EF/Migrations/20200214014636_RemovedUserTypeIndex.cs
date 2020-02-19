using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Auth.EF.Migrations
{
    public partial class RemovedUserTypeIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User.Cred",
                table: "User.Cred");

            migrationBuilder.DropIndex(
                name: "IX_User.Cred_UserID",
                table: "User.Cred");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User.Cred",
                table: "User.Cred",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User.Cred",
                table: "User.Cred");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User.Cred",
                table: "User.Cred",
                columns: new[] { "UserID", "UserType" });

            migrationBuilder.CreateIndex(
                name: "IX_User.Cred_UserID",
                table: "User.Cred",
                column: "UserID",
                unique: true);
        }
    }
}
