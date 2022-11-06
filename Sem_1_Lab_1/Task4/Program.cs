using System;

namespace Task4
{
	class Program
	{
		static void Main(string[] args) 
		{
			int a = 0;
			double x =3;

			while(x > Math.PI)
			{
				x -= Math.PI;
			}

			Console.WriteLine(Sin(x,11));
		}

		static double Sin(double x, int a)
		{
			double res = 0;

			double factorial = 1;
			double exponent = x;

			int minus = 1;


			for (int n = 3; n <= a; n+=2)
			{

				res += minus * (exponent / factorial);

                factorial = factorial * (n - 1) * n;

                exponent *= x * x;


            
                minus *= -1;
            }
            return res;
		}
	}
}