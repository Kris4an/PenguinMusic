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
        public Genres(int id, string name)
        {
            GenreId = id;
            Name = name;
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Performers> Performers { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
