using System;
using System.IO;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Task 1.
    /// Write a program to create a text file that contains 2 lines.The content of the file should be
    /// displayed on the screen.
    /// </summary>
    class Program
	{
		static void Main(string[] args)
		{
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string directory = Path.Combine(Directory.GetCurrentDirectory(), "data");
            if(!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string source = Path.Combine(directory, "text.txt");


            FileInfo file = new FileInfo(source);

            if (!file.Exists) 
            {
                using (StreamWriter sw = file.CreateText())
                {
                    sw.WriteLine("Lorem Ipsum is simply dummy text of the printing and typesetting");
                    sw.WriteLine("Contrary to popular belief, Lorem Ipsum is not simply random text.");
                }
            }

            using (StreamReader sr = file.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }



        }
	}
}

