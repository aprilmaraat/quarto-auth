using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Auth.EF.Migrations
{
    public partial class AddUserTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [enum.User.Type] (ID, Name) 
VALUES (1, 'Land Owner')
, (2, 'Tenant');
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM [enum.User.Type] WHERE ID IN (1, 2)");
        }
    }
}
