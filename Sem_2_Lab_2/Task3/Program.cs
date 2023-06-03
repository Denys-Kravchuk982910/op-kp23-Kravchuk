using System;
using Task3.Classes;

namespace Task3
{
    class Program
    {
        static void Main(string[] args) 
        {
            Vector v1 = new Vector(-5, -4, -3, -2, -1, 1, 2, 3, 4, 5);
            Vector v2 = new Vector(-10, -9, -8, -7, -6, 6, 7, 8, 9,0, 10);

            int sumOfNegativeElementsByTwoVectors = v1 + v2;
            int multiplicationOfPairElementsByVectors = v1 * v2;
            int countOfZeroElements = v1;
            countOfZeroElements += v2;

            Console.WriteLine("Sum of negative items: " + sumOfNegativeElementsByTwoVectors);
            Console.WriteLine("Multiplication of pair items: " + multiplicationOfPairElementsByVectors);
            Console.WriteLine("Count of zero items: " + countOfZeroElements);
        }
    }
}
