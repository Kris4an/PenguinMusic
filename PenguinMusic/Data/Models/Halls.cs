using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class Halls
    {
        public Halls()
        {
            Concerts = new HashSet<Concerts>();
        }

        public int HallsId { get; set; }
        public string HallName { get; set; }
        public int CityId { get; set; }
        public int NoOfSeats { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Concerts> Concerts { get; set; }

        public override string ToString()
        {
            return $"[green3]{HallName}, {City}";
        }
    }
}
