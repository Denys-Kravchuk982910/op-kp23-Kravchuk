using System;

namespace Task4
{
	class Program
	{
        /// <summary>
        ///  test cases:
		///  input:
		///  x = 3.14
		///  output:
		///  0.0084...
		///  
		///	 input: 
		///	 1.57
		///	 output: 
		///	 1.00000
		///	 
		///		input: 
		///		10
		///		output:
		///		0,5440211109464015
		///		correct: -0,5440211109464015
        /// </summary>
        static void Main(string[] args) 
		{
			int a = 0;
			double x =100;
			int sign = 1;

			if(x < 0)
			{
				sign = -1;
				x = -1 * x;
			}


			while(x > Math.PI)
			{
				x -= Math.PI;
				sign *= -1;
			}

			Console.WriteLine(sign * Sin(x,11));
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