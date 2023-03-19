using PenguinMusic.Data;
using PenguinMusic.Data.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenguinMusic.Presentation
{
    class DisplayHalls
    {
        public DisplayHalls()
        {
            var highlightStyle = new Style().Foreground(Color.Gold3_1);
            List<string> citiesString = new List<string>();
            citiesString.Add("All");
            List<Cities> cities = new CityData().GetCities();
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

            if (citySelector == "[red3]Back[/]")
            {
                Console.Clear();
                return;
            }

            var table = new Table();
            table.Title(citySelector + " performers", new Style().Foreground(Color.DeepPink4).Background(Color.Silver));
            table.AddColumn(new TableColumn("Name").Centered());
            table.AddColumn(new TableColumn("Seats").Centered());
            table.AddColumn(new TableColumn("City").Centered());

            foreach (var hall in citySelector.Equals("All") ? new HallData().GetAllHalls() : new HallData().GetHallsByCity(cities[citiesString.IndexOf(citySelector) - 1].CityId))
            {
                table.AddRow("[blueviolet]" + hall.HallName + "[/]", "[deepskyblue4]" + hall.NoOfSeats + "[/]", new CityData().GetCity(hall.CityId).ToString());
            }
            table.Border(TableBorder.Ascii);
            AnsiConsole.Write(table);
            AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("Back to the menu")
                        .HighlightStyle(highlightStyle)
                        .AddChoices(new[] { "Back" }));
            Console.Clear();
        }
    }
}
