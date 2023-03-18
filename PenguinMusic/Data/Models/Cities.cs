using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Halls = new HashSet<Halls>();
        }
        public Cities(int id, string name, string country)
        {
            CityId = id;
            CityName = name;
            Country = country;
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Halls> Halls { get; set; }

        public override string ToString()
        {
            return $"[green4]{CityName}[/], [darkgreen]{Country}[/]"; 
        }
    }
}
