using System;

namespace Task1
{
	class Program
	{
        /// <summary>
        ///     test cases:
        ///     1. 
        ///     x0 = 3
        ///     xn = 7
        ///     n = 5
        ///     
        ///     res:
        ///     correct:
        ///     x = 3 f(x) = 1,620236897377221
        ///     x = 4 f(x) = 1,7957688460974273
        ///     x = 5 f(x) = 1,9476350793851671
        ///     x = 6 f(x) = 2,080285212378517
        ///     x = 7 f(x) = 2,1976807829026157
        ///     
        ///     output of program:
        ///     x = 3 f(x) = 1,6733255689340942
        ///     x = 4 f(x) = 1,8257801601000436
        ///     x = 5 f(x) = 1,9658030160557989
        ///     x = 6 f(x) = 2,0920684484867382
        ///     x = 7 f(x) = 2,205771585883228
        ///     
        /// 
        ///     2. 
        ///     x0 = 1
        ///     xn = 4
        ///     n = 4
        ///     res:
        ///     correct: 
        ///     x = 1 f(x) = 1,1627623185780682
        ///     x = 2 f(x) = 1,4175443611198906
        ///     x = 3 f(x) = 1,620236897377221
        ///     x = 4 f(x) = 1,7957688460974273
        ///     
        ///     output of program:
        ///     x = 1 f(x) = 1,291062378397985
        ///     x = 2 f(x) = 1,5112943611198906
        ///     x = 3 f(x) = 1,6733255689340942
        ///     x = 4 f(x) = 1,8257801601000436
        /// </summary>

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
            for (double x = x0; x <= xn; x += dx)
            {
                double y = ResFormula(x, b);
                Console.WriteLine("x = " + x + " f(x) = " + y);
            }


        }

		static double ResFormula(double x, int b) 
		{
            if(x == b)
            {
                return 0;
            }
            double sqrt = Math.Sqrt(Math.Abs(x - b));
            double pow1_5 = Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)), 3.0/2.0);
            double logE = Math.Log(Math.Abs(x - b));

            return (sqrt / pow1_5) + logE;
           
		}
	}
}