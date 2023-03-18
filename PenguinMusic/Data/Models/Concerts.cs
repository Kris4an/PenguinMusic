using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class Concerts
    {
        public Concerts()
        {
            SoldTickets = new HashSet<SoldTickets>();
        }
        public Concerts(int concertId, int hallId, int performerId, DateTime dateTime, bool available, int price)
        {
            ConcertId = concertId;
            HallId = hallId;
            PerformerId = performerId;
            DateAndTime = dateTime;
            Price = price;
        }

        public int ConcertId { get; set; }
        public int HallId { get; set; }
        public int PerformerId { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool Available { get; set; }
        public int? Price { get; set; }

        public virtual Halls Hall { get; set; }
        public virtual Performers Performer { get; set; }
        public virtual ICollection<SoldTickets> SoldTickets { get; set; }

        public override string ToString()
        {
            string dateTime = DateAndTime.ToString("dd/MMM/yyyy H:mm");
            //return $"[{color}]{Performer.PerformerName}[/], {Hall}, [yellow]{dateTime}[/], [deepskyblue2]{Price}[/]";
            return $"[blueviolet]{new PerformerData().GetPerformerName(PerformerId)}[/], [orange3]{new HallData().GetHallName(HallId)}[/], [yellow1]{dateTime}[/], [deepskyblue2]{Price}BGN[/]";
        }
    }
}
