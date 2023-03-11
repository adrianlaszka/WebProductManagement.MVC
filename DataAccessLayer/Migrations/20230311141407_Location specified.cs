using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProductManagement.MVC.Data.Migrations
{
    public partial class Locationspecified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectID = table.Column<int>(type: "int", nullable: false),
                    projectCurrentStat = table.Column<int>(type: "int", nullable: false),
                    statusChanged = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProductID",
                table: "Locations",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Products_ProductID",
                table: "Locations",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Products_ProductID",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ProductID",
                table: "Locations");
        }
    }
}
