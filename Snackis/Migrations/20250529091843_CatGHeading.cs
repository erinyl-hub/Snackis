using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackis.Migrations
{
    /// <inheritdoc />
    public partial class CatGHeading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Headings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Headings_CategorieId",
                table: "Headings",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Headings_Categories_CategorieId",
                table: "Headings",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Headings_Categories_CategorieId",
                table: "Headings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Headings_CategorieId",
                table: "Headings");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Headings");
        }
    }
}
