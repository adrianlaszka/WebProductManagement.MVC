using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProductManagement.MVC.Data.Migrations
{
    public partial class warehouseforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WarehouseID",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_WarehouseID",
                table: "Locations",
                column: "WarehouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Warehouses_WarehouseID",
                table: "Locations",
                column: "WarehouseID",
                principalTable: "Warehouses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Warehouses_WarehouseID",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_WarehouseID",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseID",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
