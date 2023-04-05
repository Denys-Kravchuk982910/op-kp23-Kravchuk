using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Tools;

namespace Task3.Classes
{
    public class Vector
    {
        private CustomList<Number> _numbers;
        public Vector(params int[] arguments)
        {
            _numbers = new CustomList<Number>();
            foreach (var item in arguments)
            {
                _numbers.Add(new Number(item));
            }
        }

        public int Length 
        { get => _numbers.Count;}

        public static int operator + (Vector v1, Vector v2)
        {
            return 0;
        }

        public static int operator * (Vector v1, Vector v2)
        {
            return 0;
        }

        public static implicit operator int(Vector v1)
        {
            return 0;
        }
    }
}
