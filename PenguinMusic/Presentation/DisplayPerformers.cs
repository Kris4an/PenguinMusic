using PenguinMusic.Data;
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
            var table = new Table();
            table.AddColumn(new TableColumn("Name").Centered());
            table.AddColumn(new TableColumn("Genre").Centered());

            foreach(var performer in new PerformerData().GetAllPerformers())
            {
                table.AddRow("[blueviolet]" + performer.PerformerName + "[/]", "[deepskyblue4]"+performer.GetPerformerGenre()+"[/]");
            }
            table.Border(TableBorder.Ascii);
            AnsiConsole.Write(table);
            var backSelector = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("Back to the menu")
                                .HighlightStyle(new Style().Foreground(Color.Gold3_1))
                                .AddChoices(new [] {"Back"}));
            Console.Clear();
            return;
        }
    }
}
