using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Performers = new HashSet<Performers>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Performers> Performers { get; set; }
    }
}
