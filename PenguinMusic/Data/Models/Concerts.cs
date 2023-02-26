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
            string color = "white";
            /*switch (Performer.GenreId)
            {
                case 1:
                    {
                        color = "darkred";
                        break;
                    }
                case 2:
                    {
                        color = "indianred_1";
                        break;
                    }
                case 3:
                    {
                        color = "sandybrown";
                        break;
                    }
                case 4:
                    {
                        color = "navyblue";
                        break;
                    }
                case 5:
                    {
                        color = "white";
                        break;
                    }
                case 6:
                    {
                        color = "mediumpurple3";
                        break;
                    }
                case 7:
                    {
                        color = "greenyellow";
                        break;
                    }

            }*/
            string dateTime = DateAndTime.ToString();
            //return $"[{color}]{Performer.PerformerName}[/], {Hall}, [yellow]{dateTime}[/], [deepskyblue2]{Price}[/]";
            return $"[{color}]{PerformerId}[/], {HallId}, [yellow]{dateTime}[/], [deepskyblue2]{Price}[/]";
        }
    }
}
