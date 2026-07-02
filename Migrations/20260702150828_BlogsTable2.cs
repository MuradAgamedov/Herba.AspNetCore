using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herba.Migrations
{
    /// <inheritdoc />
    public partial class BlogsTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTranslation_Blog_BlogId",
                table: "BlogTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTranslation",
                table: "BlogTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "BlogTranslation",
                newName: "BlogTranslations");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTranslation_BlogId_LanguageCode",
                table: "BlogTranslations",
                newName: "IX_BlogTranslations_BlogId_LanguageCode");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTranslation_BlogId",
                table: "BlogTranslations",
                newName: "IX_BlogTranslations_BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_Slug",
                table: "Blogs",
                newName: "IX_Blogs_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTranslations",
                table: "BlogTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTranslations_Blogs_BlogId",
                table: "BlogTranslations",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTranslations_Blogs_BlogId",
                table: "BlogTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogTranslations",
                table: "BlogTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "BlogTranslations",
                newName: "BlogTranslation");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTranslations_BlogId_LanguageCode",
                table: "BlogTranslation",
                newName: "IX_BlogTranslation_BlogId_LanguageCode");

            migrationBuilder.RenameIndex(
                name: "IX_BlogTranslations_BlogId",
                table: "BlogTranslation",
                newName: "IX_BlogTranslation_BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_Slug",
                table: "Blog",
                newName: "IX_Blog_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogTranslation",
                table: "BlogTranslation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTranslation_Blog_BlogId",
                table: "BlogTranslation",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
