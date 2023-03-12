using System;
using System.IO; 
namespace HomeWork7
{
    class Program
    {
        static int SIZE = 10;

        static string DIRECTORY = Path.Combine(Directory.GetCurrentDirectory(), "Files");
        private static string SOURCE = Path.Combine(DIRECTORY, "source.txt");
        private static string DESTINATION = Path.Combine(DIRECTORY, "output.txt");
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World");

            int[] numbers = SeedFile();


            int [] sorted = SortItemsByBubbleSort(numbers);

            FillInFileData(sorted);
        }


        static int[] SeedFile()
        {
            if (!Directory.Exists(DIRECTORY)) Directory.CreateDirectory(DIRECTORY);
            if (!File.Exists(SOURCE)) File.Create(SOURCE);
            if (!File.Exists(DESTINATION)) File.Create(DESTINATION);


            int[] numbers = new int[SIZE];

            using (StreamReader sr = new StreamReader(SOURCE))
            {
                if (string.IsNullOrEmpty(sr.ReadToEnd()))
                {
                    using (StreamWriter sw = new StreamWriter(SOURCE))
                    {
                        Random random = new Random();
                        for (int i = 0; i < 10; i++)
                        {
                            int number = random.Next(1, 10);
                            sw.WriteLine(number);
                        }
                    }
                }
            }

            
            using (var streamReader = new StreamReader(SOURCE))
            {
                int i = 0;
                do
                {
                    numbers[i] = int.Parse(streamReader.ReadLine());
                    i++;
                } while (!streamReader.EndOfStream);
            }

           

            return numbers;
        }

        static int[] SortItemsByBubbleSort(int[] numbers)
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE - i-1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            return numbers;
        }

        static int[] SortItemsByInsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int temp = numbers[i];
                int j;
                for (j = i - 1; j >= 0 && numbers[j] > temp; j--) 
                {
                    numbers[j + 1] = numbers[j];
                }

                numbers[j + 1] = temp;
            }
            return numbers;
        }

        static int[] SortItemsBySelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length-1; i++)
            {
              
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[i]) 
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            return numbers;
        }

        static void FillInFileData(int[] numbers)
        {
            using (StreamWriter sw = new StreamWriter(DESTINATION, append:false))
            {
                for (int i = 0; i < SIZE; i++)
                {
                    sw.WriteLine(numbers[i]);
                }
            }
        }
    }
}