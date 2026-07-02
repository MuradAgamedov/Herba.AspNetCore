using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herba.Migrations
{
    /// <inheritdoc />
    public partial class HeroTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Badge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PrimaryButtonText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondaryButtonText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrustBadge1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TrustBadge2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TrustBadge3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SampleResultTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Stat1Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stat1Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stat2Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stat2Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stat3Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stat3Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecommendationText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroTranslations_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroTranslations_HeroId_LanguageCode",
                table: "HeroTranslations",
                columns: new[] { "HeroId", "LanguageCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroTranslations");

            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
