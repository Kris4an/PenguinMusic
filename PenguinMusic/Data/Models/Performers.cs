using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class Performers
    {
        public Performers()
        {
            Concerts = new HashSet<Concerts>();
        }

        public int PerformerId { get; set; }
        public string PerformerName { get; set; }
        public int GenreId { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual ICollection<Concerts> Concerts { get; set; }

    }
}
