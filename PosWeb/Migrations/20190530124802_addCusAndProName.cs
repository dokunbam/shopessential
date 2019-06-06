using Microsoft.EntityFrameworkCore.Migrations;

namespace PosWeb.Migrations
{
    public partial class addCusAndProName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Sale",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Sale");
        }
    }
}
