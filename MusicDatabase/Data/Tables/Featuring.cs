using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.Data.Tables
{
    public partial class Featuring
    {
        [Key]
        public int FeaturingId { get; set; }
        public int? SongId { get; set; }
        public int? ArtistId { get; set; }

        public virtual Song Song { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
