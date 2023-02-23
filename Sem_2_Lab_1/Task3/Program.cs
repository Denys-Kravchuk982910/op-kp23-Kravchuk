using System;
using System.Text;

namespace Task3
{
    /// <summary>
    /// Task 3.
    /// The text file contains arbitrary English words, 1 word per line, no more than 40 words in the
    /// file, the word length is limited to 80 characters.Rewrite words to another file by sorting them
    /// alphabetically.
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
            string source = Path.Combine(directory, "task3.txt");


            FileInfo file = new FileInfo(source);
        }


        static void FillFile(FileInfo file) 
        {
        
        }

        static void SortWords(FileInfo info)
        {

        }

        static int CompareWords(string str1, string str2)
        {
            return 0;
        }

        static void WriteSortedWords(FileInfo destination) 
        {
        
        }

        
    }
}
