using PenguinMusic.Data;
using PenguinMusic.Data.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenguinMusic.Presentation
{
    class DisplayAdmin
    {
        public DisplayAdmin()
        {
            var highlightStyle = new Style().Foreground(Color.Gold3_1);
            while (true)
            {
                var menuSelector = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("[gold3_1]Menu[/]")
                        .HighlightStyle(highlightStyle)
                        .AddChoices(new[] {
                        "Add performer", "Add concert", "Add genre", "Add hall", "Add city", "See all sold tickets", "[red3]Back[/]"
                        }));

                switch (menuSelector)
                {
                    case "Add performer":
                        {
                            var name = AnsiConsole.Ask<string>("What's the performer's [purple4_1]name[/]?");

                            List<string> genresString = new List<string>();
                            List<Genres> genres = new GenreData().GetGenres();
                            foreach (var genre in genres)
                            {
                                genresString.Add(genre.ToString());
                            }
                            genresString.Add("[red3]Back to the admin menu[/]");

                            var genreSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]What's the performer's genre[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(genresString.ToArray()));

                            if (genreSelector == "[red3]Back to the admin menu[/]")
                            {
                                break;
                            }
                            new PerformerData().Add(new Performers(0, name, genres[genresString.IndexOf(genreSelector)].GenreId));

                            break;
                        }
                    case "Add genre":
                        {
                            var confirm = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]Do you want to continue?[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(new[] { "No", "Yes" }));
                            if (confirm.Equals("No"))
                            {
                                break;
                            }
                            new GenreData().Add(AnsiConsole.Ask<string>("What's the genre [purple4_1]called[/]?"));

                            break;
                        }
                    case "Add concert":
                        {
                            List<string> performersString = new List<string>();
                            List<Performers> performers = new PerformerData().GetAllPerformers();
                            foreach (var performer in performers)
                            {
                                performersString.Add(performer.ToString());
                            }
                            performersString.Add("[red3]Back[/]");

                            var performerSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]Who is the performer?[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(performersString.ToArray()));

                            if (performerSelector.Equals("[red3]Back[/]"))
                            {
                                break;
                            }

                            List<string> hallsString = new List<string>();
                            List<Halls> halls = new HallData().GetAllHalls();
                            foreach (var hall in halls)
                            {
                                hallsString.Add(hall.ToString());
                            }
                            hallsString.Add("[red3]Back[/]");

                            var hallSelector = AnsiConsole.Prompt(
                               new SelectionPrompt<string>()
                               .Title("[gold3_1]Where is the concert?[/]")
                               .HighlightStyle(highlightStyle)
                               .AddChoices(hallsString.ToArray()));

                            if (hallSelector.Equals("[red3]Back[/]"))
                            {
                                break;
                            }

                            var dateTime = AnsiConsole.Prompt(
                                new TextPrompt<DateTime>("What's the [purple4_1]date and time[/] of the concert?")
                                .PromptStyle("green")
                                   .ValidationErrorMessage("[red]That's not a valid date and time[/]")
                                   .Validate(dateTime =>
                                   {
                                       try
                                       {
                                           dateTime.ToString("dd/MMM/yyyy H:mm");
                                           return ValidationResult.Success();
                                       }
                                       catch
                                       {
                                           return ValidationResult.Error("[red]Invalid date and time[/]");
                                       }
                                   }));

                            var price = AnsiConsole.Ask<int>("What's the [purple4_1]price[/] of the ticket?");

                            new ConcertData().Add(halls[hallsString.IndexOf(hallSelector)].HallsId,
                                performers[performersString.IndexOf(performerSelector)].PerformerId,
                                dateTime,
                                price);

                            break;
                        }
                    case "Add city":
                        {
                            var confirm = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[gold3_1]Do you want to continue?[/]")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(new[] { "No", "Yes" }));
                            if (confirm.Equals("No"))
                            {
                                break;
                            }
                            new CityData().Add(AnsiConsole.Ask<string>("What's the city [purple4_1]called[/]?"), AnsiConsole.Ask<string>("In which country is [purple4_1]the city[/]?"));

                            break;
                        }
                    case "Add hall":
                        {
                            string name = AnsiConsole.Ask<string>("What's the hall [purple4_1]called[/]?");
                            int seats = AnsiConsole.Ask<int>("How many [purple4_1]seats[/] are there?");

                            List<string> citiesString = new List<string>();
                            List<Cities> cities = new CityData().GetCities();
                            foreach (var city in cities)
                            {
                                citiesString.Add(city.ToString());
                            }
                            citiesString.Add("[red3]Back[/]");

                            if (citiesString.Equals("[red3]Back[/]"))
                            {
                                break;
                            }
                            var citySelector = AnsiConsole.Prompt(
                               new SelectionPrompt<string>()
                               .Title("[gold3_1]Where is the hall?[/]")
                               .HighlightStyle(highlightStyle)
                               .AddChoices(citiesString.ToArray()));

                            new HallData().Add(name, seats, cities[citiesString.IndexOf(citySelector)].CityId);

                            break;
                        }
                    case "See all sold tickets":
                        {
                            List<Ticket> tickets = new TicketData().GetSoldTickets();
                            foreach (Ticket ticket in tickets)
                            {
                                AnsiConsole.MarkupLine(ticket.ToString());
                            }
                            AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("Back to the menu")
                                .HighlightStyle(highlightStyle)
                                .AddChoices(new[] { "Back" }));
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
