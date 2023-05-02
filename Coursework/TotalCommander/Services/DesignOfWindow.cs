using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Services
{
    public static class DesignOfWindow
    {
        public static void MakeLogo() 
        {
            ConsoleColor defaultB = Console.BackgroundColor;
            ConsoleColor defaultF = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            int left = Console.LargestWindowWidth/5;
            Console.SetCursorPosition(left, 0);
            Console.WriteLine(@"___________     __         .__    _________                                   .___            ");
            Console.SetCursorPosition(left, 1);
            Console.WriteLine(@"\__    ___/____/  |______  |  |   \_   ___ \  ____   _____ _____    ____    __| _/___________ ");
            Console.SetCursorPosition(left, 2);

            Console.WriteLine(@"  |    | /  _ \   __\__  \ |  |   /    \  \/ /  _ \ /     \\__  \  /    \  / __ |/ __ \_  __ \");
            Console.SetCursorPosition(left, 3);

            Console.WriteLine(@"  |    |(  <_> )  |  / __ \|  |__ \     \___(  <_> )  Y Y  \/ __ \|   |  \/ /_/ \  ___/|  | \/");
            Console.SetCursorPosition(left, 4);

            Console.WriteLine(@"  |____| \____/|__| (____  /____/  \______  /\____/|__|_|  (____  /___|  /\____ |\___  >__|   ");
            Console.SetCursorPosition(left, 5);

            Console.WriteLine(@"                         \/               \/             \/     \/     \/      \/    \/       ");
            Console.BackgroundColor = defaultB;
            Console.ForegroundColor = defaultF;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
