using Microsoft.EntityFrameworkCore.Migrations;

namespace PosWeb.Migrations
{
    public partial class AddfieldstoSalesOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesOutputId",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "GetSalesOutputs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesDetailsID",
                table: "GetSalesOutputs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionStaff",
                table: "GetSalesOutputs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_SalesOutputId",
                table: "Sale",
                column: "SalesOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_GetSalesOutputs_SaleId",
                table: "GetSalesOutputs",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_GetSalesOutputs_SalesDetailsID",
                table: "GetSalesOutputs",
                column: "SalesDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_GetSalesOutputs_Sale_SaleId",
                table: "GetSalesOutputs",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GetSalesOutputs_SalesDetail_SalesDetailsID",
                table: "GetSalesOutputs",
                column: "SalesDetailsID",
                principalTable: "SalesDetail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_GetSalesOutputs_SalesOutputId",
                table: "Sale",
                column: "SalesOutputId",
                principalTable: "GetSalesOutputs",
                principalColumn: "SalesOutputId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetSalesOutputs_Sale_SaleId",
                table: "GetSalesOutputs");

            migrationBuilder.DropForeignKey(
                name: "FK_GetSalesOutputs_SalesDetail_SalesDetailsID",
                table: "GetSalesOutputs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_GetSalesOutputs_SalesOutputId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_SalesOutputId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_GetSalesOutputs_SaleId",
                table: "GetSalesOutputs");

            migrationBuilder.DropIndex(
                name: "IX_GetSalesOutputs_SalesDetailsID",
                table: "GetSalesOutputs");

            migrationBuilder.DropColumn(
                name: "SalesOutputId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "GetSalesOutputs");

            migrationBuilder.DropColumn(
                name: "SalesDetailsID",
                table: "GetSalesOutputs");

            migrationBuilder.DropColumn(
                name: "TransactionStaff",
                table: "GetSalesOutputs");
        }
    }
}
