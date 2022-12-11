using System;

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 3, 3, 3, 3, (3), 3, 3, 5, 8, 9, 10, 12 };
            ShowLimits(arr, 3);
        }

        static int[] BinarySearch(int[] arr, int el)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int i = (left + right) / 2;

                if (el == arr[i])
                {
                    int indexToRight = i;
                    int indexToLeft = i;
                    while (arr[indexToRight + 1] == el)
                    {
                        indexToRight++;
                    }

                    while (arr[indexToLeft - 1] == el)
                    {
                        indexToLeft--;
                    }


                    return new[] { indexToLeft, indexToRight };
                }
                else if (el < arr[i])
                {
                    right = i - 1;
                }
                else
                {
                    left = i + 1;
                }
            }

            return new[] { -1, -1 };
        }

        static void ShowLimits(int[] arr, int item)
        {
            Console.WriteLine("Left limit: " + BinarySearch(arr, item)[0]);
            Console.WriteLine("Right limit: " + BinarySearch(arr, item)[1]);
        }
    }
}

