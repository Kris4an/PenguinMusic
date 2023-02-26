using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class SoldTickets
    {
        public int TicketId { get; set; }
        public string Name { get; set; }
        public int ConcertId { get; set; }

        public virtual Concerts Concert { get; set; }
    }
}
