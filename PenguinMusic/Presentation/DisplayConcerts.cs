using System;
using System.Collections.Generic;
using System.Text;
using PenguinMusic.Data;
using PenguinMusic.Data.Models;
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
                            "All available", "Filter by genre", "Filter by city", "Past and present concerts", "[red3]Back[/]"
                        }));

                switch (menuSelector)
                {
                    case "All available":
                        {
                            List<string> concertsString = new List<string>();
                            var concerts = new ConcertData().GetAlailableConcerts();
                            foreach ( var concert in concerts)
                            {
                                concertsString.Add(concert.ToString());
                            }
                            concertsString.Add("[red3]Back[/]");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]All available concerts[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concertsString.ToArray()));

                            if (concertSelector == "[red3]Back[/]") break;

                            Concerts c = concerts[concertsString.IndexOf(concertSelector)];
                            BuyTicket(c.ConcertId, c.Price == null ? 0 : c.Price.Value);

                            break;
                        }
                    case "Past and present concerts":
                        {
                            List<string> concertsString = new List<string>();
                            var concerts = new ConcertData().GetAllConcerts();
                            foreach (var concert in concerts)
                            {
                                concertsString.Add(concert.ToString());
                            }
                            concertsString.Add("[red3]Back[/]");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]All available concerts[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concertsString.ToArray()));

                            if (concertSelector == "[red3]Back[/]") break;


                            break;
                        }
                    case "Filter by genre":
                        {
                            List<string> genresString = new List<string>();
                            List<Genres> genres = new GenreData().GetGenres();
                            foreach ( var genre in genres)
                            {
                                genresString.Add(genre.ToString());
                            }
                            genresString.Add("[red3]Back[/]");

                            var genreSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]Select genre[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(genresString.ToArray()));

                            if(genreSelector == "[red3]Back[/]") break;

                            List<string> concertsString = new List<string>();
                            var concerts = new ConcertData().GetConcertsByGenre(genres[genresString.IndexOf(genreSelector)].GenreId);
                            foreach (var concert in concerts)
                            {
                                concertsString.Add(concert.ToString());
                            }
                            concertsString.Add("[red3]Back[/]");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title($"[gold3_1]All available {genreSelector} concerts[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concertsString.ToArray()));

                            if (concertSelector == "[red3]Back[/]") break;

                            Concerts c = concerts[concertsString.IndexOf(concertSelector)];
                            BuyTicket(c.ConcertId, c.Price == null ? 0 : c.Price.Value);

                            break;
                        }
                    case "Filter by city":
                        {
                            List<string> citiesString = new List<string>();
                            List < Cities > cities= new CityData().GetCities();
                            foreach (var city in cities)
                            {
                                citiesString.Add(city.ToString());
                            }
                            citiesString.Add("[red3]Back[/]");

                            var citySelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]Select city[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(citiesString.ToArray()));

                            if (citySelector == "[red3]Back[/]") break;

                            List<string> concertsString = new List<string>();
                            var concerts = new ConcertData().GetConcertsByCity(cities[citiesString.IndexOf(citySelector)].CityId);
                            foreach (var concert in concerts)
                            {
                                concertsString.Add(concert.ToString());
                            }
                            concertsString.Add("[red3]Back[/]");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title($"[gold3_1]All available concerts in {citySelector}[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concertsString.ToArray()));

                            if (concertSelector == "[red3]Back[/]") break;

                            Concerts c = concerts[concertsString.IndexOf(concertSelector)];
                            BuyTicket(c.ConcertId, c.Price==null? 0:c.Price.Value);

                            break;
                        }
                    case "[red3]Back[/]":
                        {
                            Console.Clear();
                            return;
                        }
                }
            }
        }
        private void BuyTicket(int concertId, int price)
        {
            var highlightStyle = new Style().Foreground(Color.Gold3_1);
            string name = AnsiConsole.Ask<string>("What's your [purple4_1]name[/]?");
            var confirm = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title($"[gold3_1]The price of the ticket is [deepskyblue2]{price}BGN. [/]Do you want to continue?[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(new[] { "No", "Yes" }));
            if (confirm.Equals("No"))
            {
                return;
            }
            new TicketData().BuyTicket(name, concertId);
            AnsiConsole.MarkupLine(new Ticket(name, concertId).ToString());
            AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("Back to the menu")
                        .HighlightStyle(highlightStyle)
                        .AddChoices(new[] { "Back" }));
        }
    }
}
