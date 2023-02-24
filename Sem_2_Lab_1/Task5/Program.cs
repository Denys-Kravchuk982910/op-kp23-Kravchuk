using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Task5
{
    /// <summary>
    /// Task 5 (task from interview).
    /// Write a program that will calculate the number of each word in a text file.
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
            string source = Path.Combine(directory, "task5.txt");

            FileInfo file = new FileInfo(source);
            if (!file.Exists)
            {
                using (StreamWriter sw = file.CreateText())
                {
                    sw.Write("Lorem, ipsum dolor sit amet, consectetur adipiscing elit. Aenean at malesuada lectus. Maecenas eu odio velit. " +
                        "Donec dapibus lectus eu velit eleifend faucibus. Donec et mattis metus. Aenean aliquam urna non iaculis tristique. " +
                        "Suspendisse malesuada ultrices neque, sed varius mi posuere eget. Curabitur aliquet dolor eros, ac pharetra ligula tempor ac ac ac ac.");
                }
            }


            using (StreamReader sr = file.OpenText())
            {
                string formatedString = "";
                int countOfWords = 0;
                char item = (char)sr.Read();
                while (!sr.EndOfStream)
                {

                    string word = "";
                    while (item != ' ' && item != '.' && item != ',')
                    {
                        word += item;
                        item = (char)sr.Read();
                    }
                    item = (char)sr.Read();
                    if(word.Length > 0)
                    {
                        formatedString += word + "\n"; 
                        countOfWords++;
                    }
                }

                while (formatedString.Length > 0) 
                {
                    string word = "";
                    int i = 0;
                    while (formatedString[i] != '\n') 
                    {
                        word += formatedString[i];
                        i++;
                    }

                    Console.WriteLine($"Count of word \"{word}\" is {CustomContains(formatedString, word)}");
                    formatedString = CustomReplaceClear(formatedString, word);
                }
            }
        }

        static int CustomContains(string text, string inside) 
        {
            int count = 0;
            int i = 0;
            //for (i = 0; i < text.Length-(inside.Length-2); i++)
            while(i < text.Length - (inside.Length - 2))
            {
                bool isChecked = true;
                int j = 0;
                //for (int j = 0; j < inside.Length; j++)
                while (text[i] != '\n')
                {
                    if (j >= inside.Length || text[i] != inside[j])
                    {
                        isChecked = false;
                    }
                    j++;
                    i++;
                }
                if(isChecked)
                {
                    count += 1;
                }
                i++;
            }
            return count;
        }

        static string CustomReplaceClear(string text, string word) 
        {
            int i = 0;
            string newString = "";
            while (i < text.Length)
            {
                string lineText = "";

                while (text[i] != '\n') 
                {
                    lineText += text[i];
                    i++;
                }
                i++;
                if (word.Length == lineText.Length)
                {
                    bool flag = true;
                    
                    for (int k = 0; k < word.Length; k++)
                    {
                        if (lineText[k] != word[k])
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        continue;
                    }
                }
                newString += lineText + "\n";
            }

            return newString;
        }
    }
}
