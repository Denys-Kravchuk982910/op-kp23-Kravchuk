using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2.Abstracts;

namespace Task2_2.Classes
{
    public class SailingVessel : Vessel
    {
        public override void PrepareToMovement()
        {
            base.PrepareToMovement();
            Console.WriteLine("Sails are ready to conquer your goals!");
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("We have caught the wind and we are waiting on your commands! Captain!");
        }
    }
}
