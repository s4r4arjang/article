using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtrinCode.Infrastructures.EFCore.Migrations
{
    public partial class addColumnArticleImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArticleImage",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ArticleImage",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValueSql: "1");
        }
    }
}
