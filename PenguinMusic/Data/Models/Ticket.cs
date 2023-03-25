using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class Ticket
    {
        public Ticket(string name, int concertId)
        {
            Name = name;
            ConcertId = concertId;
        }
        public Ticket(int id, string name, int concertId)
        {
            TicketId = id;
            Name = name;
            ConcertId = concertId;
        }
        public int TicketId { get; set; }
        public string Name { get; set; }
        public int ConcertId { get; set; }

        public virtual Concerts Concert { get; set; }

        public override string ToString()
        {
            Concerts c = new ConcertData().getConcertById(ConcertId);
            string s = 
            ("[gold1]******************************************************[/]") + "\n" +
            ("[gold1]\\    ╔╗  ╔╦═══╦╗ ╔╦═══╗╔════╦══╦═══╦╗╔═╦═══╦════╗    /[/]") + "\n" +
             ("[gold1]/    ║╚╗╔╝║╔═╗║║ ║║╔═╗║║╔╗╔╗╠╣╠╣╔═╗║║║╔╣╔══╣╔╗╔╗║    \\[/]") + "\n" +
            ("[gold1]\\    ╚╗╚╝╔╣║ ║║║ ║║╚═╝║╚╝║║╚╝║║║║ ╚╣╚╝╝║╚══╬╝║║╚╝    /[/]") + "\n" +
             ("[gold1]/     ╚╗╔╝║║ ║║║ ║║╔╗╔╝  ║║  ║║║║ ╔╣╔╗║║╔══╝ ║║      \\[/]") + "\n" +
            ("[gold1]\\      ║║ ║╚═╝║╚═╝║║║╚╗  ║║ ╔╣╠╣╚═╝║║║╚╣╚══╗ ║║      /[/]") + "\n" +
             ("[gold1]/      ╚╝ ╚═══╩═══╩╝╚═╝  ╚╝ ╚══╩═══╩╝╚═╩═══╝ ╚╝      \\[/]") + "\n" +
            ("[gold1]\\                                                    /[/]") + "\n" +
            ($"[gold1]/{FillUpBlankSpace("  NAME: "+Name)}\\[/]") + "\n" +
            ($"[gold1]\\{FillUpBlankSpace("  DATE AND TIME: "+ c.DateAndTime)}/[/]") + "\n" +
            ($"[gold1]/{FillUpBlankSpace("  LOCATION: "+new HallData().GetHallById(c.HallId).ToStringNoMarkup())}\\[/]") + "\n" +
            ($"[gold1]\\                                                    /[/]") + "\n" +
            ("[gold1]******************************************************[/]");
            return s;
        }
        private string FillUpBlankSpace(string name)
        {
            if (name.Length >= 52) return name.Substring(0, 52);
            int n = 52 - name.Length;
            return name + string.Concat(System.Linq.Enumerable.Repeat(' ', (int)n));
        }
    }
}
