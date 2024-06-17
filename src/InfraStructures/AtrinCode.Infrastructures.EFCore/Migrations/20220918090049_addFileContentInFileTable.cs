using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtrinCode.Infrastructures.EFCore.Migrations
{
    public partial class addFileContentInFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Articles_ArticleId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Files",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Articles_ArticleId",
                table: "Files",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Articles_ArticleId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Files",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Articles_ArticleId",
                table: "Files",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }
    }
}
