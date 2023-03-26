using PenguinMusic.Data;
using PenguinMusic.Data.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenguinMusic.Presentation
{
    class DonateDisplay
    {
        public DonateDisplay()
        {
            List<Donation> donations = new DonationData().GetTop3Donators();
            AnsiConsole.Write(new BarChart()
            .Width(60)
            .Label("[orangered1 bold underline]Top donators in BGN[/]")
            .CenterLabel()
            .AddItems(donations, (donation) => new BarChartItem(
                 donation.Name, donation.Amount, donation.DonationId%2==0? Color.DeepSkyBlue1:Color.Green3_1)));

            string name = AnsiConsole.Ask<string>("What's your [purple4_1]name[/]?");
            int amount = AnsiConsole.Prompt(new TextPrompt<int>("How much do you want to [deepskyblue2]donate[/]?")
                .ValidationErrorMessage("[red]The donation amount needs to be a positive integer.[/]")
                .Validate(amount =>
                {
                    if (amount < 0) return ValidationResult.Error("[red]The donation amount needs to be a positive integer.[/]");
                    return ValidationResult.Success();
                }
                ));
            string confirm = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title($"[gold3_1]Are you sure you want to donate [deepskyblue2]{amount}BGN[/] to the PenguinMusic Charity?[/]")
                                .HighlightStyle(new Style().Foreground(Color.Gold3_1))
                                .AddChoices(new[] { "No", "Yes" }));
            if(confirm.Equals("No"))
            {
                AnsiConsole.Clear();
                return;
            }
            new DonationData().Add(name, amount);
            AnsiConsole.Prompt(
                       new SelectionPrompt<string>()
                       .Title("[deeppink4_1 bold]Thank you for being a good human![/]")
                       .HighlightStyle(new Style().Foreground(Color.Gold3_1))
                       .AddChoices(new[] { "Back" }));
            AnsiConsole.Clear();
        }
    }
}
