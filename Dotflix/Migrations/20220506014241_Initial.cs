using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDotflix.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Language_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Language_Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "MovieLanguage",
                columns: table => new
                {
                    Language_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Movie_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguage", x => new { x.Movie_Id, x.Language_Id });
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Language_Language_Id",
                        column: x => x.Language_Id,
                        principalTable: "Language",
                        principalColumn: "Language_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Movie_Movie_Id",
                        column: x => x.Movie_Id,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_Language_Id",
                table: "MovieLanguage",
                column: "Language_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieLanguage");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
