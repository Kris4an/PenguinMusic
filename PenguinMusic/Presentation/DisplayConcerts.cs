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
                            List<string> concerts = new List<string>();
                            foreach( var concert in new ConcertData().GetAlailableConcerts())
                            {
                                concerts.Add(concert.ToString());
                            }
                            concerts.Add("[red3]Back[/]");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]All available concerts[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concerts.ToArray()));

                            if (concertSelector == "[red3]Back[/]") break;


                            break;
                        }
                    case "Past and present concerts":
                        {
                            List<string> concerts = new List<string>();
                            foreach (var concert in new ConcertData().GetAllConcerts())
                            {
                                concerts.Add(concert.ToString());
                            }
                            concerts.Add("[red3]Back[/]");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]All available concerts[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concerts.ToArray()));

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

                            List<string> concerts = new List<string>();
                            foreach (var concert in new ConcertData().GetConcertsByGenre(genres[genresString.IndexOf(genreSelector)].GenreId))
                            {
                                concerts.Add(concert.ToString());
                            }
                            concerts.Add("[red3]Back[/]");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title($"[gold3_1]All available {genreSelector} concerts[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concerts.ToArray()));

                            if (concertSelector == "[red3]Back[/]") break;

                            switch (concertSelector)
                            {

                            }


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

                            List<string> concerts = new List<string>();
                            foreach (var concert in new ConcertData().GetConcertsByCity(cities[citiesString.IndexOf(citySelector)].CityId))
                            {
                                concerts.Add(concert.ToString());
                            }
                            concerts.Add("[red3]Back[/]");

                            var concertSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title($"[gold3_1]All available concerts in {citySelector}[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(concerts.ToArray()));

                            if (concertSelector == "[red3]Back[/]") break;

                            switch (concertSelector)
                            {

                            }


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
    }
}
