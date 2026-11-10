using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.NewsLetter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "newsletter");

            migrationBuilder.CreateTable(
                name: "articles",
                schema: "newsletter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    PublishedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    cover_image_storage_key = table.Column<string>(type: "text", nullable: true),
                    cover_image_alt_text = table.Column<string>(type: "text", nullable: true),
                    cover_image_content_type = table.Column<string>(type: "text", nullable: true),
                    cover_image_width = table.Column<int>(type: "integer", nullable: true),
                    cover_image_height = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_Status_PublishedAt",
                schema: "newsletter",
                table: "articles",
                columns: new[] { "Status", "PublishedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles",
                schema: "newsletter");
        }
    }
}
