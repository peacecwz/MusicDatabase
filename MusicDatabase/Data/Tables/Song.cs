using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.Data.Tables
{
    public partial class Song
    {
        [Key]
        public int SongId { get; set; }
        public string SongName { get; set; }
        public int? GenreId { get; set; }
        public string Language { get; set; }
        public int? AlbumId { get; set; }
        public int? ArtistId { get; set; }
        public bool? IsFeaturing { get; set; }

        public virtual Album Album { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Lyric Lyric { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual List<Featuring> Featurings { get; set; }
    }
}
