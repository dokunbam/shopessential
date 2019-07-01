using Microsoft.EntityFrameworkCore.Migrations;

namespace PosWeb.Migrations
{
    public partial class newUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sale_SalesSaleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Stores_StoreId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_SubStores_Stores_StoreId",
                table: "SubStores");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SalesSaleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SalesSaleId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "SubStores",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SubStores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Staff",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Staff",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SalesDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "SalesDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Sale",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "GetSalesOutputs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "GetSalesOutputs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Category",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ApplicationUserId",
                table: "Sale",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AspNetUsers_ApplicationUserId",
                table: "Sale",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Stores_StoreId",
                table: "Sale",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubStores_Stores_StoreId",
                table: "SubStores",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AspNetUsers_ApplicationUserId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Stores_StoreId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_SubStores_Stores_StoreId",
                table: "SubStores");

            migrationBuilder.DropIndex(
                name: "IX_Sale_ApplicationUserId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SubStores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SalesDetail");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "SalesDetail");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "GetSalesOutputs");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "GetSalesOutputs");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "SubStores",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "Sale",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SalesSaleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SalesSaleId",
                table: "AspNetUsers",
                column: "SalesSaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sale_SalesSaleId",
                table: "AspNetUsers",
                column: "SalesSaleId",
                principalTable: "Sale",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Stores_StoreId",
                table: "Sale",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubStores_Stores_StoreId",
                table: "SubStores",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
