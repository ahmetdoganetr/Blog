using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    EditedDate = table.Column<DateTime>(nullable: false),
                    EditorId = table.Column<int>(nullable: false),
                    ArticleCategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    ArticleCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    EditedDate = table.Column<DateTime>(nullable: false),
                    EditorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.ArticleCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    EditedDate = table.Column<DateTime>(nullable: false),
                    EditorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
