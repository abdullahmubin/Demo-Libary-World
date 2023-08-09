using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoLibWorld.Migrations
{
    public partial class addFKInBookBookCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCategoryId",
                table: "BoookCollectoins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoookCollectoins_BookCategoryId",
                table: "BoookCollectoins",
                column: "BookCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoookCollectoins_BookCategories_BookCategoryId",
                table: "BoookCollectoins",
                column: "BookCategoryId",
                principalTable: "BookCategories",
                principalColumn: "BookCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoookCollectoins_BookCategories_BookCategoryId",
                table: "BoookCollectoins");

            migrationBuilder.DropIndex(
                name: "IX_BoookCollectoins_BookCategoryId",
                table: "BoookCollectoins");

            migrationBuilder.DropColumn(
                name: "BookCategoryId",
                table: "BoookCollectoins");
        }
    }
}
