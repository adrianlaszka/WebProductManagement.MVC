using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProductManagement.MVC.Data.Migrations
{
    public partial class correctionoftables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxNumberOfProductPerCell",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Warehouses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProjectStatuses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Locations",
                newName: "WarehouseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Warehouses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ProjectStatuses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WarehouseID",
                table: "Locations",
                newName: "ProductName");

            migrationBuilder.AddColumn<int>(
                name: "MaxNumberOfProductPerCell",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
