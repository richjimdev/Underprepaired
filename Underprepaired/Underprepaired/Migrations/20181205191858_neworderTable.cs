using Microsoft.EntityFrameworkCore.Migrations;

namespace Underprepaired.Migrations
{
    public partial class neworderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders",
                nullable: true);
        }
    }
}
