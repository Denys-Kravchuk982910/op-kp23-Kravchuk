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
		static void Main(string[] args)
		{
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string directory = Path.Combine(Directory.GetCurrentDirectory(), "data");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string source = Path.Combine(directory, "text.txt");


            FileInfo file = new FileInfo(source);
		}

        static void CreateFileWithNumbers(FileInfo file) 
        {
            
        }

        static void FindMaximumNumberInFile(FileInfo file)
        {

        }
	}
}