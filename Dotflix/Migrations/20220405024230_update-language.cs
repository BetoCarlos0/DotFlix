using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotflix.Migrations
{
    public partial class updatelanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sinopse = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Age_group = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Release_data = table.Column<DateTime>(type: "date", nullable: false),
                    Relevance = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    RunTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_Language_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Language_MovieId",
                table: "Language",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
