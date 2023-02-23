﻿using Bogus;
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
        static int MAX_WORDS_IN_FILE = 40;
        static void Main(string[] args) 
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string directory = Path.Combine(Directory.GetCurrentDirectory(), "data");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string source = Path.Combine(directory, "task3.txt");


            FileInfo file = new FileInfo(source);
            FillFile(file);
            string[] sorted = SortWords(file);


            FileInfo dest = new FileInfo(Path.Combine(directory, "result.txt"));
            WriteSortedWords(dest, sorted);
        }

        static void FillFile(FileInfo file) 
        {
            if (!file.Exists)
            {
                Faker faker = new Faker("en");
                string fileWord;
                using (StreamWriter sw = file.CreateText()) 
                {
                    for (int i = 0; i < MAX_WORDS_IN_FILE; i++)
                    {
                        fileWord = faker.Lorem.Word();
                        sw.WriteLine(fileWord);
                    }
                }
            }
        }

        static string[] SortWords(FileInfo info)
        {
            string[] sortedWords = new string[MAX_WORDS_IN_FILE];

            using (StreamReader sr = info.OpenText())
            {
                int counter = 1;
                string line = sr.ReadLine();
                sortedWords[counter - 1] = line;
                while (!sr.EndOfStream)
                {
                    int i;
                    line = sr.ReadLine();
                    for (i = counter; i > 0 && CompareWords(line, sortedWords[i-1], counter) == -1; i--)
                    {
                        sortedWords[i] = sortedWords[i-1];
                    }

                    sortedWords[i] = line;


                    counter++;
                }
            }

            return sortedWords;
        }

        /// <param name="str1">First string</param>
        /// <param name="str2">Second string</param>
        /// <returns>Return smaller string (-1, 0, 1)</returns>
        static int CompareWords(string str1, string str2, int counter)
        {
            // Defining of word, which has less length
            int minLength = str1.Length;
            int lessWord = -1;
            if(minLength > str2.Length)
            {
                minLength = str2.Length;
                lessWord = 1;
            }

            // Comparing char symbols
            for (int i = 0; i < minLength; i++) 
            {
                if (str2[i] != str1[i])
                {
                    if (str1[i] < str2[i])
                    {
                        return -1;
                    }
                    return 1;
                }
            }

            // Return 0, when the values have the same symbols
            if (str1.Length == str2.Length)
                return 0;
            // Return lessWord, when the roots of these words are equal,
            // but length one of them is less than other one
            return lessWord;
        }

        static void WriteSortedWords(FileInfo destination, string[] sortedList) 
        {
            using (StreamWriter sw = new StreamWriter(destination.OpenWrite())) 
            {
                foreach (var item in sortedList)
                {
                    sw.WriteLine(item);
                }
            }
        }

        
    }
}
