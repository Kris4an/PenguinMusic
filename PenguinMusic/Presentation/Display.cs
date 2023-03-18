using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace PenguinMusic.Presentation
{
    class Display
    {
        private Canvas DrawPenguin(Canvas canvas)
        {
            for (int i = 2; i <= 6; i++)
            {

                canvas.SetPixel(i, 1, Color.Purple_2);
                for (int j = 2; j <= 6; j++)
                {
                    canvas.SetPixel(7, i, Color.Grey23);
                    canvas.SetPixel(1, i, Color.Grey23);
                    if (i == 6) break;
                    canvas.SetPixel(j, i, Color.White);
                }
                canvas.SetPixel(i, 7, Color.Orange3);
            }
            for (int i = 3; i <= 5; i++)
            {
                canvas.SetPixel(i, 0, Color.DeepPink1_1);
                canvas.SetPixel(i, 3, Color.OrangeRed1);
                canvas.SetPixel(i, 6, Color.Grey62);
                canvas.SetPixel(0, i, Color.Grey19);
                canvas.SetPixel(8, i, Color.Grey19);
            }
            canvas.SetPixel(3, 2, Color.Grey11);
            canvas.SetPixel(5, 2, Color.Grey11);
            canvas.SetPixel(2, 6, Color.Grey19);
            canvas.SetPixel(6, 6, Color.Grey19);
            canvas.SetPixel(2, 5, Color.Grey62);
            canvas.SetPixel(6, 5, Color.Grey62);
            canvas.SetPixel(4, 2, Color.Grey42);
            canvas.SetPixel(4, 7, Color.Grey23);

            return canvas;
        }
        private Panel LogoTitle()
        {
            string s = "\n██████╗░███████╗███╗░░██╗░██████╗░██╗░░░██╗██╗███╗░░██╗  ███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░" +
                       "\n██╔══██╗██╔════╝████╗░██║██╔════╝░██║░░░██║██║████╗░██║  ████╗░████║██║░░░██║██╔════╝██║██╔══██╗" +
                       "\n██████╔╝█████╗░░██╔██╗██║██║░░██╗░██║░░░██║██║██╔██╗██║  ██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝" +
                       "\n██╔═══╝░██╔══╝░░██║╚████║██║░░╚██╗██║░░░██║██║██║╚████║  ██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗" +
                       "\n██║░░░░░███████╗██║░╚███║╚██████╔╝╚██████╔╝██║██║░╚███║  ██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝" +
                       "\n╚═╝░░░░░╚══════╝╚═╝░░╚══╝░╚═════╝░░╚═════╝░╚═╝╚═╝░░╚══╝  ╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░";

            Canvas penguinDrawing = new Canvas(9, 8);
            penguinDrawing = DrawPenguin(penguinDrawing);

            Grid mainTitle = new Grid();
            mainTitle.AddColumn();
            mainTitle.AddColumn();
            mainTitle.AddRow(new Text(s, new Style(Color.Orchid, Color.Black)).LeftJustified(), penguinDrawing);

            Panel mainTitlePanel = new Panel(mainTitle);
            mainTitlePanel.Border = BoxBorder.Ascii;
            return mainTitlePanel;
        }
        public Display()
        {
            Panel logoTitle = LogoTitle();

            Grid mainHolder = new Grid();
            mainHolder.AddColumn();
            mainHolder.AddRow(logoTitle);
            var highlightStyle = new Style().Foreground(Color.Gold3_1);
            while (true)
            {
                AnsiConsole.Write(mainHolder);
                //Prompt for the main menu
                var menuSelector = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[gold3_1]Menu[/]")
                    .HighlightStyle(highlightStyle)
                    .AddChoices(new[] {
                        "Concerts", "Performers", "Halls", "Donate", "Admin", "Exit"
                    }));

                switch (menuSelector)
                {
                    case "Concerts":
                        {
                            DisplayConcerts dc = new DisplayConcerts();
                            break;
                        }
                    case "Performers":
                        {
                            DisplayPerformers dp = new DisplayPerformers();
                            break;
                        }
                    case "Halls":
                        {
                            DisplayHalls dh = new DisplayHalls();
                            break;
                        }
                    case "Donate":
                        {

                            break;
                        }
                    case "Admin":
                        {

                            break;
                        }
                    case "Exit":
                        {
                            return;
                        }
                }
            }
            
        }
    }
}
