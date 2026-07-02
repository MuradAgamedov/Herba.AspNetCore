using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herba.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabaseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategoryTranslationS_BlogCategories_BlogCategoryId",
                table: "BlogCategoryTranslationS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogCategoryTranslationS",
                table: "BlogCategoryTranslationS");

            migrationBuilder.RenameTable(
                name: "BlogCategoryTranslationS",
                newName: "BlogCategoryTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_BlogCategoryTranslationS_BlogCategoryId",
                table: "BlogCategoryTranslations",
                newName: "IX_BlogCategoryTranslations_BlogCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogCategoryTranslations",
                table: "BlogCategoryTranslations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategoryTranslations_BlogCategories_BlogCategoryId",
                table: "BlogCategoryTranslations",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategoryTranslations_BlogCategories_BlogCategoryId",
                table: "BlogCategoryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogCategoryTranslations",
                table: "BlogCategoryTranslations");

            migrationBuilder.RenameTable(
                name: "BlogCategoryTranslations",
                newName: "BlogCategoryTranslationS");

            migrationBuilder.RenameIndex(
                name: "IX_BlogCategoryTranslations_BlogCategoryId",
                table: "BlogCategoryTranslationS",
                newName: "IX_BlogCategoryTranslationS_BlogCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogCategoryTranslationS",
                table: "BlogCategoryTranslationS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategoryTranslationS_BlogCategories_BlogCategoryId",
                table: "BlogCategoryTranslationS",
                column: "BlogCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
