using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.Data.Tables
{
    public partial class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string Country { get; set; }
        public string Barcode { get; set; }
        public bool? IsSingle { get; set; }
        public int? ArtistId { get; set; }
        public int? ReleaseYear { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
