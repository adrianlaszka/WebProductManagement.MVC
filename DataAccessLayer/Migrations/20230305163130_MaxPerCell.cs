using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProductManagement.MVC.Data.Migrations
{
    public partial class MaxPerCell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageUrL",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "MaxPerCell",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPerCell",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrL",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
