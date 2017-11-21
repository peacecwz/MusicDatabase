using Microsoft.EntityFrameworkCore;
using System;
using MusicDatabase.Data.Tables;

namespace MusicDatabase.Data
{
    public partial class MusicDbContext : DbContext
    {
        public MusicDbContext() { }

        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Featuring> Featurings { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Lyric> Lyrics { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.AlbumId);



                entity.Property(e => e.AlbumId)
                    .HasColumnName("album_id")
                    .ValueGeneratedOnAdd()
                    .UseNpgsqlSerialColumn();

                entity.Property(e => e.AlbumName)
                    .HasColumnName("album_name")
                    .HasColumnType("varchar");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar");

                entity.Property(e => e.IsSingle).HasColumnName("is_single");

                entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.Property(e => e.ArtistId)
                    .HasColumnName("artist_id")
                    .ValueGeneratedOnAdd()
                    .UseNpgsqlSerialColumn(); 

                entity.Property(e => e.ArtistName)
                    .HasColumnName("artist_name")
                    .HasColumnType("varchar");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar");

                entity.Property(e => e.IsGroup).HasColumnName("is_group");

                entity.Property(e => e.RealName)
                    .HasColumnName("real_name")
                    .HasColumnType("varchar");

                entity.Property(e => e.StartedYear).HasColumnName("started_year");
            });

            modelBuilder.Entity<Featuring>(entity =>
            {
                entity.HasKey(e => e.FeaturingId);

                entity.Property(e => e.FeaturingId)
                    .HasColumnName("featuring_id")
                    .ValueGeneratedOnAdd()
                    .UseNpgsqlSerialColumn();

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.SongId).HasColumnName("song_id");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .ValueGeneratedOnAdd()
                    .UseNpgsqlSerialColumn();

                entity.Property(e => e.GenreName)
                    .HasColumnName("genre_name")
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<Lyric>(entity =>
            {
                entity.HasKey(e => e.LyricId);

                entity.Property(e => e.LyricId)
                    .HasColumnName("lyric_id")
                    .ValueGeneratedOnAdd()
                    .UseNpgsqlSerialColumn();

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasColumnType("varchar");

                entity.Property(e => e.Lyrics1).HasColumnName("lyrics");

                entity.Property(e => e.SongId).HasColumnName("song_id");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(e => e.SongId);

                entity.Property(e => e.SongId)
                    .HasColumnName("song_id")
                    .ValueGeneratedOnAdd()
                    .UseNpgsqlSerialColumn();

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.IsFeaturing).HasColumnName("is_featuring");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasColumnType("varchar");

                entity.Property(e => e.SongName)
                    .HasColumnName("song_name")
                    .HasColumnType("varchar");
            });
        }
    }
}
