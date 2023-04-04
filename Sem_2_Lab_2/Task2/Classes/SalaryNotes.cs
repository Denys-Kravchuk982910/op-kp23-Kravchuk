using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Classes;
using Task2.Tools;

namespace Task2.Classes
{
    public class SalaryNotes
    {
        private CustomList<SalaryNote> _customList;

        public SalaryNotes()
        {
            this._customList = new CustomList<SalaryNote>();
        }


        public void GetReport()
        {
            Console.WriteLine("Id | Surname | Salary | Delayed | Paid");

            for (int i = 0; i < _customList.Count; i++)
            {
                Console.WriteLine((i + 1) + "   " + _customList[i]);
            }
            Console.ReadKey();

        }

        public void AddItem(SalaryNote note) 
        {
            this._customList.Add(note);
        }
    }
}
