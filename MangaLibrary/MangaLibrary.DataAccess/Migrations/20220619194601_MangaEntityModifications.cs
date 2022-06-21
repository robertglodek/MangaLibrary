using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaLibrary.DataAccess.Migrations
{
    public partial class MangaEntityModifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Demographic",
                table: "Mangas");

            migrationBuilder.RenameColumn(
                name: "Publisher",
                table: "Volumes",
                newName: "Arc");

            migrationBuilder.RenameColumn(
                name: "Publisher",
                table: "Mangas",
                newName: "Status");

            migrationBuilder.AddColumn<bool>(
                name: "AnimeAdaptation",
                table: "Mangas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DemographicId",
                table: "Mangas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Heroes",
                table: "Mangas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Story",
                table: "Mangas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Demographics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_DemographicId",
                table: "Mangas",
                column: "DemographicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Demographics_DemographicId",
                table: "Mangas",
                column: "DemographicId",
                principalTable: "Demographics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Demographics_DemographicId",
                table: "Mangas");

            migrationBuilder.DropTable(
                name: "Demographics");

            migrationBuilder.DropIndex(
                name: "IX_Mangas_DemographicId",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "AnimeAdaptation",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "DemographicId",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "Heroes",
                table: "Mangas");

            migrationBuilder.DropColumn(
                name: "Story",
                table: "Mangas");

            migrationBuilder.RenameColumn(
                name: "Arc",
                table: "Volumes",
                newName: "Publisher");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Mangas",
                newName: "Publisher");

            migrationBuilder.AddColumn<string>(
                name: "Demographic",
                table: "Mangas",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }
    }
}
