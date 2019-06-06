using Microsoft.EntityFrameworkCore.Migrations;

namespace PosWeb.Migrations
{
    public partial class AddIcollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Sale",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CategoryId",
                table: "Sale",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Category_CategoryId",
                table: "Sale",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Category_CategoryId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_CategoryId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sale");
        }
    }
}
