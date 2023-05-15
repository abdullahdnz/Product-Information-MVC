using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductInfo.Migrations
{
    public partial class removeCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CustomerID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerID",
                table: "Products",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerID",
                table: "Products",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
