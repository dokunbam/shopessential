using Microsoft.EntityFrameworkCore.Migrations;

namespace PosWeb.Migrations
{
    public partial class AddCustomerNameToSalesOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomersName",
                table: "GetSalesOutputs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomersName",
                table: "GetSalesOutputs");
        }
    }
}
