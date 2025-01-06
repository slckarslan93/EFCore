using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemo2.Migrations
{
    /// <inheritdoc />
    public partial class updateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_DirectorId",
                schema: "ef",
                table: "Movies");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                schema: "ef",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                schema: "ef",
                table: "Movies",
                column: "GenreId",
                principalSchema: "ef",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                schema: "ef",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                schema: "ef",
                table: "Movies");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_DirectorId",
                schema: "ef",
                table: "Movies",
                column: "DirectorId",
                principalSchema: "ef",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
