using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProductManagement.MVC.Data.Migrations
{
    public partial class WarehousesProjectstatutestablesadded : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectStatuses");
        }
    }
}
