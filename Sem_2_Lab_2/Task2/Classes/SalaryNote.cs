using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Classes
{
    public class SalaryNote
    {
        private string _surname;
        private double _salary;
        private double _received;
        private double _withheld;


        public SalaryNote(string surname, double salary, double withheld)
        {
            this._surname = surname;
            this._salary = salary;
            this._withheld = withheld;

            this._received = this._salary - this._withheld;
        }

        public string Surname
        {
            get => this._surname;
        }

        public double Salary
        {
            get => this._salary;
        }

        public double Received
        {
            get => this._received;
        }

        public double Withheld
        {
            get => this._withheld;
        }

        public void GetReport() 
        {
            Console.WriteLine("Id | Surname | Salary | Delayed | Paid");
            Console.WriteLine(1 + "   " + this.ToString());
            Console.ReadKey();
        }

        public override string ToString()
        {
            return this._surname + " | " + this._salary + " | " + this._withheld + " | " + this._received;
        }
    }
}
