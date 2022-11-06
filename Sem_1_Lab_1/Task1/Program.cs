using System;

namespace Task1
{
	class Program
	{
		static void Main(string[] args) 
		{
			double x0 = 0;
			double xn = 0;
			double n = 0;
			int b = -2;

            Console.Write("Enter x0 - ");
            x0 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter xn - ");
            xn = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter n - ");
            n = Convert.ToDouble(Console.ReadLine());

            double dx = (xn - x0) / (n-1);
            // y = |x - b|^1/2 / |b^3 - x^3|^3/2 + ln|x - b|
            for (double x = x0; x <= xn; x += dx)
            {
                double y = ResFormula(x, b);
                Console.WriteLine("x = " + x + " f(x) = " + y);
            }
        }

		static double ResFormula(double x, int b) 
		{
            double sqrt = Math.Sqrt(Math.Abs(x - b));
            double pow1_5 = Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)), 3/2);
            double logE = Math.Log(Math.Abs(x - b));

            return (sqrt / pow1_5) + logE;
           
		}
	}
}