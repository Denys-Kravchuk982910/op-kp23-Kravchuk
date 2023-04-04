using System;
using Task2.Classes;

namespace Task2
{
    class Program
    {
        static void Main(string[] args) 
        {
            SalaryNotes notes = new SalaryNotes();

            var item = new SalaryNote("Kravchuk", 1000, 200);
            notes.AddItem(item);
            notes.AddItem(new SalaryNote("Petrov", 1000, 250));
            notes.AddItem(new SalaryNote("Kuchma", 1000, 200));
            notes.AddItem(new SalaryNote("Sholz", 1000, 400));

            //Report from one item
            item.GetReport();
            Console.WriteLine("==================================");
            //Report from collection of these items
            notes.GetReport();
        }
    }
}