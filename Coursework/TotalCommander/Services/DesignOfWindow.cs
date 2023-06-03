using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Services
{
    public static class DesignOfWindow
    {
        private static List<string> _options { get; set; }
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

        public static void MakeBackground()
        {
            var back = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            for (int i = 6; i < Console.WindowHeight / 2 + 21; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.WriteLine(" ");
                }
            }

            Console.BackgroundColor = back;
        }

        public static void MakeBorders()
        {
            var back = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            var fore = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int start = 8;
            for(int i = start; i < Console.WindowWidth/2; i++)
            {
                Console.SetCursorPosition(i, start);
                Console.WriteLine("_");

                Console.SetCursorPosition(Console.WindowWidth / 2 -start +i, start);
                Console.WriteLine("_");

                Console.SetCursorPosition(i, Console.WindowHeight-1);
                Console.WriteLine("_");

                Console.SetCursorPosition(Console.WindowWidth / 2 - start + i, Console.WindowHeight-1);
                Console.WriteLine("_");
            }


            start++;
            for (int i = start; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(start-1, i);
                Console.WriteLine("|");

                Console.SetCursorPosition(Console.WindowWidth-10, i);
                Console.WriteLine("|");
                
                Console.SetCursorPosition(Console.WindowWidth/2, i);
                Console.WriteLine("||");
            }

            //Console.SetCursorPosition(start, i);
            //Console.WriteLine("*");


            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;

        }

        public static void MakePointers(List<string> options)
        {
            _options = options;
            ClearConsoleLine(String.Join("  |  ", options.Select(x => x)));
        }

        public static string ClearConsoleLine(string? text = null, bool question = false) 
        {
            string output = " ";
            var defBack = Console.BackgroundColor;
            var defFore = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            int left = 10;
            int top = 7;
            while (left < (Console.WindowWidth) - 10)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(" ");
                left++;
            }
            if(text != null && !question)
            {
                Console.SetCursorPosition(10, top);
                Console.WriteLine(text);
            }
            
            if(text != null && question)
            {
                Console.SetCursorPosition(10, top);
                Console.Write(text);
                output = Console.ReadLine()!;
                ClearConsoleLine(String.Join("  |  ", _options.Select(x => x)));
            }

            Console.BackgroundColor = defBack;
            Console.ForegroundColor = defFore;

            return output!;
        }
    }
}
