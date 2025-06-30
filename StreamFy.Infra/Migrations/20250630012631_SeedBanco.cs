using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StreamFy.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Bohemian Rhapsody" },
                    { 2, "Stairway to Heaven" },
                    { 3, "Hotel California" },
                    { 4, "Sweet Child O' Mine" },
                    { 5, "Imagine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
