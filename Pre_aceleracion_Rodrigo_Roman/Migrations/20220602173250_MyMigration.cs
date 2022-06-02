using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pre_aceleracion_Rodrigo_Roman.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Lore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asociated_Movie_Serie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovieSeries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Release_Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false),
                    GenresID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSeries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieSeries_Genres_GenresID",
                        column: x => x.GenresID,
                        principalTable: "Genres",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CharactersMovieSerie",
                columns: table => new
                {
                    CharactersID = table.Column<int>(type: "int", nullable: false),
                    MovieSeriesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersMovieSerie", x => new { x.CharactersID, x.MovieSeriesID });
                    table.ForeignKey(
                        name: "FK_CharactersMovieSerie_Characters_CharactersID",
                        column: x => x.CharactersID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersMovieSerie_MovieSeries_MovieSeriesID",
                        column: x => x.MovieSeriesID,
                        principalTable: "MovieSeries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMovieSerie_MovieSeriesID",
                table: "CharactersMovieSerie",
                column: "MovieSeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSeries_GenresID",
                table: "MovieSeries",
                column: "GenresID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactersMovieSerie");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "MovieSeries");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
