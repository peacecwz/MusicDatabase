using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MusicDatabase.Migrations
{
    public partial class DbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_buffercache", "'pg_buffercache', '', ''")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", "'pg_stat_statements', '', ''");

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    artist_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    artist_name = table.Column<string>(type: "varchar", nullable: true),
                    country = table.Column<string>(type: "varchar", nullable: true),
                    is_group = table.Column<bool>(nullable: true),
                    real_name = table.Column<string>(type: "varchar", nullable: true),
                    started_year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.artist_id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    genre_name = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    album_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    album_name = table.Column<string>(type: "varchar", nullable: true),
                    artist_id = table.Column<int>(nullable: true),
                    barcode = table.Column<string>(type: "varchar", nullable: true),
                    country = table.Column<string>(type: "varchar", nullable: true),
                    is_single = table.Column<bool>(nullable: true),
                    release_year = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.album_id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_artist_id",
                        column: x => x.artist_id,
                        principalTable: "Artists",
                        principalColumn: "artist_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    song_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    album_id = table.Column<int>(nullable: true),
                    artist_id = table.Column<int>(nullable: true),
                    genre_id = table.Column<int>(nullable: true),
                    is_featuring = table.Column<bool>(nullable: true),
                    language = table.Column<string>(type: "varchar", nullable: true),
                    song_name = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.song_id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_album_id",
                        column: x => x.album_id,
                        principalTable: "Albums",
                        principalColumn: "album_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_artist_id",
                        column: x => x.artist_id,
                        principalTable: "Artists",
                        principalColumn: "artist_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Featurings",
                columns: table => new
                {
                    featuring_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    artist_id = table.Column<int>(nullable: true),
                    song_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Featurings", x => x.featuring_id);
                    table.ForeignKey(
                        name: "FK_Featurings_Artists_artist_id",
                        column: x => x.artist_id,
                        principalTable: "Artists",
                        principalColumn: "artist_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Featurings_Songs_song_id",
                        column: x => x.song_id,
                        principalTable: "Songs",
                        principalColumn: "song_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lyrics",
                columns: table => new
                {
                    lyric_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    language = table.Column<string>(type: "varchar", nullable: true),
                    lyrics = table.Column<string>(nullable: true),
                    song_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lyrics", x => x.lyric_id);
                    table.ForeignKey(
                        name: "FK_Lyrics_Songs_song_id",
                        column: x => x.song_id,
                        principalTable: "Songs",
                        principalColumn: "song_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_artist_id",
                table: "Albums",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Featurings_artist_id",
                table: "Featurings",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Featurings_song_id",
                table: "Featurings",
                column: "song_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lyrics_song_id",
                table: "Lyrics",
                column: "song_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_album_id",
                table: "Songs",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_artist_id",
                table: "Songs",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_genre_id",
                table: "Songs",
                column: "genre_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Featurings");

            migrationBuilder.DropTable(
                name: "Lyrics");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
