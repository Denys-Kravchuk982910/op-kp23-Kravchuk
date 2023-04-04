using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes
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

        public override string ToString()
        {
            return this._surname + " | " + this._salary + " | " + this._withheld + " | " + this._received;
        }
    }
}
