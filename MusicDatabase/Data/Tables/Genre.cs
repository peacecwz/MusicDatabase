using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.Data.Tables
{
    public partial class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual List<Song> Songs { get; set; }
    }
}
