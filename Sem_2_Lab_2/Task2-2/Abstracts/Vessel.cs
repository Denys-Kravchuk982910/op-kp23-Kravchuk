using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2.Abstracts
{
    public abstract class Vessel
    {
        public virtual void PrepareToMovement() 
        {
            Console.WriteLine("This vessel is completed by food and water!"); 
        }

        public virtual void Move()
        {
            Console.WriteLine("This vessel is moving to defined goal!");
        }
    }
}
