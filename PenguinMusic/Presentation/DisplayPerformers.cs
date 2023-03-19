using PenguinMusic.Data;
using PenguinMusic.Data.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenguinMusic.Presentation
{
    class DisplayPerformers
    {
        public DisplayPerformers()
        {
            var highlightStyle = new Style().Foreground(Color.Gold3_1);
            List<string> genresString = new List<string>();
            genresString.Add("All");
            List<Genres> genres = new GenreData().GetGenres();
            foreach (var genre in genres)
            {
                genresString.Add(genre.ToString());
            }
            genresString.Add("[red3]Back[/]");

            var genreSelector = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[gold3_1]Select genre[/]")
                .HighlightStyle(highlightStyle)
                .AddChoices(genresString.ToArray()));

            if (genreSelector == "[red3]Back[/]")
            {
                Console.Clear();
                return;
            }


            var table = new Table();
            table.Title(genreSelector + " performers", new Style().Foreground(Color.DeepPink4).Background(Color.Silver));
            table.AddColumn(new TableColumn("Name").Centered());
            table.AddColumn(new TableColumn("Genre").Centered());

            foreach(var performer in genreSelector.Equals("All")? new PerformerData().GetAllPerformers():new PerformerData().GetPerformersByGenre(genres[genresString.IndexOf(genreSelector)-1].GenreId))
            {
                table.AddRow("[blueviolet]" + performer.PerformerName + "[/]", "[deepskyblue4]"+performer.GetPerformerGenre()+"[/]");
            }
            table.Border(TableBorder.Ascii);
            AnsiConsole.Write(table);
            AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("Back to the menu")
                        .HighlightStyle(highlightStyle)
                        .AddChoices(new [] {"Back"}));
            Console.Clear();
        }
    }
}
