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
            int sum = 0;

            for(int i = 0; i < v1.Length; i++)
            {
                if (v1._numbers[i] < 0)
                {
                    sum+= v1._numbers[i];
                }
            }

            for (int i = 0; i < v2.Length; i++)
            {
                if (v2._numbers[i] < 0)
                {
                    sum += v2._numbers[i];
                }
            }

            return sum;
        }

        public static int operator * (Vector v1, Vector v2)
        {
            int sum = 1;
            CustomList<Number> result = v1._numbers + v2._numbers;
            for (int i = 0; i < result.Count; i+=2)
            {
                sum *= result[i];
            }
            return sum;
        }

        public static implicit operator int(Vector v1)
        {
            int count = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1._numbers[i].Value == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
