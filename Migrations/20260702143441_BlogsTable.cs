using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herba.Migrations
{
    /// <inheritdoc />
    public partial class BlogsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlogCategoryTranslations_BlogCategoryId",
                table: "BlogCategoryTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlogCategoryTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                table: "BlogCategoryTranslations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReadMinutes = table.Column<int>(type: "int", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeoTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SeoKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageAltText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogTranslation_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategoryTranslations_BlogCategoryId_LanguageCode",
                table: "BlogCategoryTranslations",
                columns: new[] { "BlogCategoryId", "LanguageCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Slug",
                table: "Blog",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogTranslation_BlogId",
                table: "BlogTranslation",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTranslation_BlogId_LanguageCode",
                table: "BlogTranslation",
                columns: new[] { "BlogId", "LanguageCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTranslation");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_BlogCategoryTranslations_BlogCategoryId_LanguageCode",
                table: "BlogCategoryTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlogCategoryTranslations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                table: "BlogCategoryTranslations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategoryTranslations_BlogCategoryId",
                table: "BlogCategoryTranslations",
                column: "BlogCategoryId");
        }
    }
}
