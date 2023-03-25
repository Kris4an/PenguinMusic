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
        public Halls(int id, string name, int cityId, int seats)
        {
            HallsId = id;
            HallName = name;
            CityId = cityId;
            NoOfSeats = seats;
        }

        public int HallsId { get; set; }
        public string HallName { get; set; }
        public int CityId { get; set; }
        public int NoOfSeats { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Concerts> Concerts { get; set; }

        public override string ToString()
        {
            return $"[green3]{HallName}, {new CityData().GetCity(CityId).CityName}[/]";
        }
        public string ToStringNoMarkup()
        {
            return $"{HallName}, {new CityData().GetCity(CityId).CityName}";
        }
    }
}
