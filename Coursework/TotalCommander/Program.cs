using System;
using System.Text;
using TotalCommander.Abstracts;
using TotalCommander.Classes;
using TotalCommander.Services;

namespace TotalCommander
{
    class Program
    {
       static void Main(string[] args) 
       {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.SetWindowSize((int)((double)Console.LargestWindowWidth / 1.2),
                (int)((double)Console.LargestWindowHeight / 1.2));

            DesignOfWindow.MakeLogo();
            DesignOfWindow.MakeBackground();
            DesignOfWindow.MakeBorders();

            List<string> options = new List<string> {
                "M - create directoy",
                "F - create file",
                "T - delete current item",
            };

            DesignOfWindow.MakePointers(options);


            MainMenu menu = new MainMenu();

            menu.StartApplication();
        }

    }
}
