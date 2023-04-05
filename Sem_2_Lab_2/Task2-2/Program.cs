using System;
using Task2_2.Abstracts;
using Task2_2.Classes;

namespace Task2
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("============== SailingVessel ==============");
            Vessel sailing = new SailingVessel();
            sailing.PrepareToMovement();
            sailing.Move();
            Console.WriteLine();
            Console.WriteLine("============== Submarine ==============");
            Vessel submarine = new Submarine();
            submarine.PrepareToMovement();
            submarine.Move();
        }
    }
}
