using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2.Abstracts;
using Task2_2.Interfaces;

namespace Task2_2.Classes
{
    public class SailingVessel : IVessel
    {
        public void PrepareToMovement()
        {
            Console.WriteLine("Sails are ready to conquer your goals!");
        }

        public void Move()
        {
            Console.WriteLine("We have caught the wind and we are waiting on your commands! Captain!");
        }
    }
}
