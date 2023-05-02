using System;
using System.Text;
using TotalCommander.Services;

namespace TotalCommander
{
    class Program
    {
       static void Main(string[] args) 
       {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.SetWindowSize((int)((double)Console.LargestWindowWidth/1.2), 
                (int)((double)Console.LargestWindowHeight/1.2));

            DesignOfWindow.MakeLogo();
            
       }
    }
}
