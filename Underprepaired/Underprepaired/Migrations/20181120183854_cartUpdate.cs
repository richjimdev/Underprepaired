using Microsoft.EntityFrameworkCore.Migrations;

namespace Underprepaired.Migrations
{
    public partial class cartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Carts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Carts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
