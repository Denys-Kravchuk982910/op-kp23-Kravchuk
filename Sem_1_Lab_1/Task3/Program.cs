using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
            uint numberOfFactorial = 0;
            int x = 1;

            Console.Write("Enter number of factorial [n]! - ");
            numberOfFactorial = Convert.ToUInt32(Console.ReadLine());

            Console.Write("Enter the base for the exponent [x] - ");
            x = Convert.ToInt32(Console.ReadLine());

            int resultFactorial = 1;

            for (int i = 1; i <= numberOfFactorial; i++)
            {
                resultFactorial *= i;
            }

            int resultExponent = (int)Math.Pow(x, numberOfFactorial);

            Console.WriteLine("x^n: " + resultExponent + "\nFactorial of n: " + resultFactorial);
        }
    }
}
