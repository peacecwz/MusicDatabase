using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.Data.Tables
{
    public partial class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Country { get; set; }
        public string RealName { get; set; }
        public bool? IsGroup { get; set; }
        public int? StartedYear { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}
