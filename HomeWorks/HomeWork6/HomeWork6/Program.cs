using System;

namespace HomeWork6
{
    class Program
    {    /// <summary>
         /// Пошук у масові наприклад: шукаємо  3 у масиві: -10 -5 -2 0 3 4 7 2 1 -1
         /// </summary>
        static void Main(string[] args)
        {
            //int[] arr = { 1, 2, 3, 3, 3, 3, 3, (3), 3, 3, 5, 8, 9, 10, 12 };
            //ShowLimits(arr, 3);

            int[] arr = { -10, -5, -2, 0, 3, 4, 7, 8, 2 };
            
            int peregyn = BinarySearchPeregyn(arr);

            int el = BinarySearch(arr, peregyn, 3);
            Console.WriteLine(el);
    {
       

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

        static int BinarySearchPeregyn(int[] arr) 
        {
            int leftLimit = 0;
            int rightLimit = arr.Length - 1;

            while (leftLimit < rightLimit) 
            {

                int middle = (leftLimit + rightLimit) / 2;

                if (arr[middle] < arr[middle + 1]) 
                {
                    leftLimit = middle + 1;
                }

                if (arr[middle] > arr[middle + 1]) 
                {
                    rightLimit = middle - 1;
                } 
            }

            return leftLimit;
        }

        static int BinarySearch(int[] arr, int peregyn, int item)
        {
            int leftLimit = 0;
            int rightLimit = peregyn;

            while (leftLimit <= rightLimit) 
            {
                int middle = (leftLimit + rightLimit) / 2;

                if (arr[middle] == item)
                {
                    return middle;
                }
                else if (arr[middle] > item)
                {
                    rightLimit = middle - 1;
                }
                else 
                {
                    leftLimit = middle + 1;
                }
            }

            leftLimit = peregyn + 1;
            rightLimit = arr.Length - 1;

            while (leftLimit <= rightLimit)
            {
                int middle = (leftLimit + rightLimit) / 2;

                if (arr[middle] == item)
                {
                    return middle;
                }
                else if (arr[middle] < item)
                {
                    rightLimit = middle - 1;
                }
                else
                {
                    leftLimit = middle + 1;
                }
            }

            return -1;
        }
    }
}

