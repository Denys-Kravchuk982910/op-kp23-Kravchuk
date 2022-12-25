using System;

namespace Task3
{
	class Program
	{
        /// <summary>
        ///     test cases:
        ///     input:
        ///     x = 2
        ///     n = 5
        ///     output: 
        ///     n! = 120
        ///     x^5 = 32
        ///     input:
        ///     x = 3
        ///     n = 4
        ///     output:  
        ///     n! = 24
        ///     x^n = 81
        /// </summary>
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
