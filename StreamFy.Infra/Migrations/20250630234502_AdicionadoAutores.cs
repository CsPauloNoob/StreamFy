using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StreamFy.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoAutores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musicas_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusicaPlaylist",
                columns: table => new
                {
                    MusicasId = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaPlaylist", x => new { x.MusicasId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_MusicaPlaylist_Musicas_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "Musicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicaPlaylist_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Queen" },
                    { 2, "Led Zeppelin" },
                    { 3, "Eagles" },
                    { 4, "Guns N' Roses" },
                    { 5, "John Lennon" },
                    { 6, "Nirvana" },
                    { 7, "Oasis" },
                    { 8, "The Beatles" },
                    { 9, "Bob Dylan" },
                    { 10, "Michael Jackson" }
                });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "AutorId", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "Bohemian Rhapsody" },
                    { 2, 2, "Stairway to Heaven" },
                    { 3, 3, "Hotel California" },
                    { 4, 4, "Sweet Child O' Mine" },
                    { 5, 5, "Imagine" },
                    { 6, 6, "Smells Like Teen Spirit" },
                    { 7, 7, "Wonderwall" },
                    { 8, 8, "Hey Jude" },
                    { 9, 9, "Like a Rolling Stone" },
                    { 10, 10, "Billie Jean" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicaPlaylist_PlaylistId",
                table: "MusicaPlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_AutorId",
                table: "Musicas",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_UsuarioId",
                table: "Playlist",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicaPlaylist");

            migrationBuilder.DropTable(
                name: "Musicas");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
