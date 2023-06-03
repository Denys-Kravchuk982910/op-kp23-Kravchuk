using System;
using Task2_2.Abstracts;
using Task2_2.Classes;
using Task2_2.Interfaces;

namespace Task2
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("============== SailingVessel ==============");
            IVessel sailing = new SailingVessel();
            sailing.PrepareToMovement();
            sailing.Move();
            Console.WriteLine();
            Console.WriteLine("============== Submarine ==============");
            IVessel submarine = new Submarine();
            submarine.PrepareToMovement();
            submarine.Move();
        }
    }
}
