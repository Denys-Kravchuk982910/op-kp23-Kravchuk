using System;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Task 2.
    /// Write a program that allows you to create a text file and write to it 15 random
    /// real numbers.The numbers should be on the same line.Find the maximum among them
    /// and write it into another file with the name max.txt
    /// </summary>
    class Program
	{
        static int LENGTH_OF_ARRAY = 10;
        /// <summary>
        ///     Test case:
        ///     Sequence of numbers: 16 8 6 12 17 8 10 8 10 7 
        ///     The max number: 17
        /// </summary>
		static void Main(string[] args)
		{
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string directory = Path.Combine(Directory.GetCurrentDirectory(), "data");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string source = Path.Combine(directory, "text.txt");


            FileInfo file = new FileInfo(source);
            CreateFileWithNumbers(file);
            int maxValue = FindMaximumNumberInFile(file);

            FileInfo sourceFile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "data", "max.txt"));
            WriteMaxResultInFile(sourceFile, maxValue);
        }

        static void CreateFileWithNumbers(FileInfo file) 
        {
            if (!file.Exists)
            {
                Random random = new Random();
                using (StreamWriter sw = file.CreateText())
                {
                    for (int i = 0; i < LENGTH_OF_ARRAY; i++)
                    {
                        sw.Write(random.Next(0, 20) + " ");
                    }
                }
            }
        }

        static int FindMaximumNumberInFile(FileInfo file)
        {
            int max = -1;
            using (StreamReader sr = file.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    string numberStr = "";
                    char item = '\0';
                    while (item != ' ')
                    {
                        item = Convert.ToChar(sr.Read());
                        numberStr += item;
                    }

                    int element = Convert.ToInt32(numberStr);

                    if(element > max)
                        max = element;
                }
            }
            return max;
        }

        static void WriteMaxResultInFile(FileInfo max, int maxValue) 
        {
            if(!max.Exists)
            {
                using (StreamWriter sw = max.CreateText()) 
                {
                    sw.Write(maxValue);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(max.OpenWrite()))
                {
                    sw.Write(maxValue);
                }
            }
        }
	}
}