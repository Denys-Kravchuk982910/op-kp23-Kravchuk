using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Task1
    {
        static void Main(string[] args)
        {
            double number = 0;
            double middle = 0;
            Console.Write("Enter number: ");

            number = Convert.ToDouble(Console.ReadLine());


            double cbrt = number / 3;
            double temp = 0;

            int numberRoot = 3;

            Console.WriteLine("root of number["+ numberRoot +"] (Math.Pow): " + Math.Pow(number, 1.0/numberRoot));

            while (cbrt != temp)
            {
                temp = cbrt;

                double tempExponentOfNumber = 1;

                for(int i= 0; i< numberRoot-1; i++)
                {
                    tempExponentOfNumber *= temp;
                }


                cbrt = (number / tempExponentOfNumber + (temp * (numberRoot-1))) / numberRoot;
            }

            middle = cbrt;
            
            Console.WriteLine("root of number ["+ numberRoot +"]: " + String.Format("{0:F" + 15 + "}", middle));
        }
    }
}
