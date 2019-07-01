using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PosWeb.Migrations
{
    public partial class AddingStoreSubstoreAndStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Sale",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    StoreName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    SalesId = table.Column<int>(nullable: false),
                    SubStoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubStores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubStoreName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StaffEmail = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    SubStoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_SubStores_SubStoreId",
                        column: x => x.SubStoreId,
                        principalTable: "SubStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_StoreId",
                table: "Sale",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_SubStoreId",
                table: "Staff",
                column: "SubStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SubStores_StoreId",
                table: "SubStores",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Stores_StoreId",
                table: "Sale",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Stores_StoreId",
                table: "Sale");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "SubStores");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Sale_StoreId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Sale");
        }
    }
}
