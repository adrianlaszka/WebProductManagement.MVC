using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProductManagement.MVC.Data.Migrations
{
    public partial class tablesinitialized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    workDuration = table.Column<int>(type: "int", nullable: false),
                    workCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetails", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStatuses_projectID",
                table: "ProjectStatuses",
                column: "projectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStatuses_ProjectDetails_projectID",
                table: "ProjectStatuses",
                column: "projectID",
                principalTable: "ProjectDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStatuses_ProjectDetails_projectID",
                table: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "ProjectDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStatuses_projectID",
                table: "ProjectStatuses");
        }
    }
}
