using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProductManagement.MVC.Data.Migrations
{
    public partial class projProdListtableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectProductLists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProductLists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectProductLists_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectProductLists_ProjectDetails_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProductLists_ProductID",
                table: "ProjectProductLists",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProductLists_ProjectID",
                table: "ProjectProductLists",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectProductLists");
        }
    }
}
