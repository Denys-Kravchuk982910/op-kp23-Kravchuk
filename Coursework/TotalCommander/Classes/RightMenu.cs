﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Abstracts;

namespace TotalCommander.Classes
{
    public class RightMenu : Menu
    {
        public RightMenu(List<ExplorerEntity> explorerEntities) : base(explorerEntities)
        {

        }


        public void DisplayRightMenu(int page = 0) 
        {
            int stop = 1;
            int start = 9;
            var back = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            //40
            for (int i = 9; i < this._explorerEntities.Count + 9 - page*31; i++)
            {
                if(stop == 1 && page == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                if(stop < 32)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 3, i);
                    Console.WriteLine(this._explorerEntities[page * 31 + i - 9].Name);
                    stop++;
                }

                if (stop == 2 && page == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
            }

            Console.BackgroundColor = back;
        }
    }
}
