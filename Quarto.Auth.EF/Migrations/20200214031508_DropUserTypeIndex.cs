using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Auth.EF.Migrations
{
    public partial class DropUserTypeIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP INDEX [User.Cred].[IX_User.Cred_UserType];");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
