using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.Data.Tables
{
    public partial class Lyric
    {
        [Key]
        public int LyricId { get; set; }
        public int? SongId { get; set; }
        public string Lyrics1 { get; set; }
        public string Language { get; set; }

        public virtual Song Song { get; set; }
    }
}
