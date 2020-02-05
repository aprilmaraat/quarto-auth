using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarto.Auth.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enum.User.Type",
                columns: table => new
                {
                    ID = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enum.User.Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User.Data",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(255)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(255)", nullable: true),
                    DisplayName = table.Column<string>(type: "varchar(255)", nullable: true),
                    PasswordChangeDT = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    ResetPassword = table.Column<bool>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.Data", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User.Cred",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    UserType = table.Column<byte>(type: "tinyint", nullable: false),
                    AuthenticationHash = table.Column<string>(nullable: true),
                    LastUsedDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.Cred", x => new { x.UserID, x.UserType });
                    table.ForeignKey(
                        name: "FK_User.Cred_User.Data",
                        column: x => x.UserID,
                        principalTable: "User.Data",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User.Cred_enum.User.Type",
                        column: x => x.UserType,
                        principalTable: "enum.User.Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User.Cred_UserID",
                table: "User.Cred",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User.Cred_UserType",
                table: "User.Cred",
                column: "UserType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User.Data_EmailAddress",
                table: "User.Data",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_User.Data_UserName",
                table: "User.Data",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User.Cred");

            migrationBuilder.DropTable(
                name: "User.Data");

            migrationBuilder.DropTable(
                name: "enum.User.Type");
        }
    }
}
