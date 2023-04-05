using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2.Abstracts;

namespace Task2_2.Classes
{
    public class Submarine : Vessel
    {
        public override void PrepareToMovement()
        {
            base.PrepareToMovement();
            Console.WriteLine("Our submarine is under of water and we are ready to conquer your goals!");
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("All engines are turned on. Let's go start!");
        }
    }
}
