using System;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
            int number = 0;

            do
            {
                Console.Write("Enter number: ");
                number = Convert.ToInt32(Console.ReadLine());
            } while (number <= 1);

            if(CheckPrime(number))
            {
                Console.WriteLine("The number is prime!");
            }else
            {

                Console.WriteLine("The number is not prime!");
            }
        }

        static bool CheckPrime(int number)
		{
            bool isPrime = false;
            if (number % 2 != 0)
            {
                if (number == 3)
                {
                    isPrime = true;
                }
                else
                {


                    for (int i = 3; i < number; i += 2)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }

                        if (i + 2 >= number - 1)
                        {
                            isPrime = true;
                        }
                    }
                }
            }
            else
            {
                if (number != 2)
                {
                    isPrime = false;
                }
                else
                {
                    isPrime = true;
                }
            }

            return isPrime;
        }
	}
}
