using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Task5
{
    /// <summary>
    /// Task 5 (task from interview).
    /// Write a program that will calculate the number of each word in a text file.
    /// </summary>
    /// 

    /// Test cases:
    /// Input:
    /// Lorem, ipsum dolor sit amet, consectetur adipiscing elit. Aenean at malesuada lectus. Maecenas eu odio velit.
    /// Donec dapibus lectus eu velit eleifend faucibus. Donec et mattis metus. Aenean aliquam urna non iaculis tristique.
    /// Suspendisse malesuada ultrices neque, sed varius mi posuere eget. Curabitur aliquet dolor eros, ac pharetra ligula tempor ac ac ac ac.
    /// 
    /// Output:
    /// Count of word "dolor" is 2
    /// Count of word "sit" is 1
    /// Count of word "amet" is 1
    /// Count of word "consectetur" is 1
    /// Count of word "adipiscing" is 1
    /// Count of word "elit" is 1
    /// Count of word "Aenean" is 2
    /// Count of word "at" is 1
    /// Count of word "malesuada" is 2
    /// Count of word "lectus" is 2
    /// Count of word "Maecenas" is 1
    /// Count of word "eu" is 2
    /// Count of word "odio" is 1
    /// Count of word "velit" is 2
    /// Count of word "Donec" is 2
    /// Count of word "dapibus" is 1
    /// Count of word "eleifend" is 1
    /// Count of word "faucibus" is 1
    /// Count of word "et" is 1
    /// Count of word "mattis" is 1
    /// Count of word "metus" is 1
    /// Count of word "aliquam" is 1
    /// Count of word "urna" is 1
    /// Count of word "non" is 1
    /// Count of word "iaculis" is 1
    /// Count of word "tristique" is 1
    /// Count of word "Suspendisse" is 1
    /// Count of word "ultrices" is 1
    /// Count of word "neque" is 1
    /// Count of word "sed" is 1
    /// Count of word "varius" is 1
    /// Count of word "mi" is 1
    /// Count of word "posuere" is 1
    /// Count of word "eget" is 1
    /// Count of word "Curabitur" is 1
    /// Count of word "aliquet" is 1
    /// Count of word "eros" is 1
    /// Count of word "ac" is 5
    /// Count of word "pharetra" is 1
    /// Count of word "ligula" is 1
    /// Count of word "tempor" is 1
    /// 
    /// Input:
    /// 
    /// Lorem ipsum dolor sit amet, consectetur adipiscing elit.Maecenas aliquam consequat dui ac auctor.Donec sapien est, semper eget sollicitudin sit amet, 
    /// dapibus non mi.Nullam non lectus sed enim vestibulum ultrices non nec nisl. Donec mattis nunc at erat elementum rhoncus.Nulla eu nulla ac neque 
    /// ultrices sodales.Maecenas id tempor quam, id iaculis magna.Nam metus nisi, faucibus nec felis et, porttitor hendrerit eros.Integer sed semper neque. 
    /// Aliquam viverra augue ac diam commodo, quis mollis tortor tempus.
    /// 
    /// Output:
    /// Count of word "Lorem" is 1
    /// Count of word "ipsum" is 1
    /// Count of word "dolor" is 1
    /// Count of word "sit" is 2
    /// Count of word "amet" is 2
    /// Count of word "consectetur" is 1
    /// Count of word "adipiscing" is 1
    /// Count of word "elit" is 1
    /// Count of word "Maecenas" is 2
    /// Count of word "aliquam" is 1
    /// Count of word "consequat" is 1
    /// Count of word "dui" is 1
    /// Count of word "ac" is 3
    /// Count of word "auctor" is 1
    /// Count of word "Donec" is 2
    /// Count of word "sapien" is 1
    /// Count of word "est" is 1
    /// Count of word "semper" is 2
    /// Count of word "eget" is 1
    /// Count of word "sollicitudin" is 1
    /// Count of word "dapibus" is 1
    /// Count of word "non" is 3
    /// Count of word "mi" is 1
    /// Count of word "Nullam" is 2
    /// Count of word "lectus" is 1
    /// Count of word "sed" is 2
    /// Count of word "enim" is 1
    /// Count of word "vestibulum" is 1
    /// Count of word "ultrices" is 2
    /// Count of word "nec" is 2
    /// Count of word "nisl" is 1
    /// Count of word "mattis" is 1
    /// Count of word "nunc" is 1
    /// Count of word "at" is 1
    /// Count of word "erat" is 1
    /// Count of word "elementum" is 1
    /// Count of word "rhoncus" is 1
    /// Count of word "Nulla" is 1
    /// Count of word "eu" is 1
    /// Count of word "nulla" is 1
    /// Count of word "neque" is 2
    /// Count of word "sodales" is 1
    /// Count of word "id" is 2
    /// Count of word "tempor" is 1
    /// Count of word "quam" is 1
    /// Count of word "iaculis" is 1
    /// Count of word "magna" is 1
    /// Count of word "Nam" is 1
    /// Count of word "metus" is 1
    /// Count of word "nisi" is 1
    /// Count of word "faucibus" is 1
    /// Count of word "felis" is 1
    /// Count of word "et" is 1
    /// Count of word "porttitor" is 1
    /// Count of word "hendrerit" is 1
    /// Count of word "eros" is 1
    /// Count of word "Integer" is 1
    /// Count of word "Aliquam" is 1
    /// Count of word "viverra" is 1
    /// Count of word "augue" is 1
    /// Count of word "diam" is 1
    /// Count of word "commodo" is 1
    /// Count of word "quis" is 1
    /// Count of word "mollis" is 1
    /// Count of word "tortor" is 1
    /// Count of word "tempus" is 1

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
                    sw.Write("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas aliquam consequat dui ac auctor." +
                        " Donec sapien est, semper eget sollicitudin sit amet, dapibus non mi. Nullam non lectus sed enim vestibulum ultrices non nec nisl." +
                        " Donec mattis nunc at erat elementum rhoncus. Nulla eu nulla ac neque ultrices sodales. Maecenas id tempor quam, id iaculis magna." +
                        " Nam metus nisi, faucibus nec felis et, porttitor hendrerit eros. Integer sed semper neque. Aliquam viverra augue ac diam commodo," +
                        " quis mollis tortor tempus.");
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
