using System;
using System.Collections.Generic;
using System.Text;
using PenguinMusic.Data;
using Spectre.Console;

namespace PenguinMusic.Presentation
{
    class DisplayConcerts
    {
        public DisplayConcerts()
        {
            var highlightStyle = new Style().Foreground(Color.Gold3_1);
            while (true)
            {
                var menuSelector = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("[gold3_1]Menu[/]")
                        .HighlightStyle(highlightStyle)
                        .AddChoices(new[] {
                            "All available", "Filter by genre", "Filter by city", "Past and present concerts", "Back"
                        }));

                switch (menuSelector)
                {
                    case "All available":
                        {
                            List<string> concerts = new List<string>();
                            foreach( var concert in new ConcertData().GetConcerts())
                            {
                                concerts.Add(concert.ToString());
                            }
                            concerts.Add("Back");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]Menu[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concerts.ToArray()));

                            if (concertSelector == "Back") break;


                            break;
                        }
                    case "Back":
                        {
                            Console.Clear();
                            return;
                        }
                }
            }
        }
    }
}
