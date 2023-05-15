using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductInfo.Migrations
{
    public partial class removeCategoryFromProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PCategory",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PCategory",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
