using System;
using System.Buffers.Text;
using System.Text;

namespace Task6
{
    class Program
    {
        /// <summary>
        /// Task 6.
        /// Read CSV file that is specified in Task 4, Create a binary file that is based on the CSV file.
        /// Read the binary file and create another binary file that will contain the number of the
        /// students whose score is greater than 95 and all the records for those students. 
        /// </summary>
        /// 


        /// Input:
        /// FirstName,LastName,Age"Листвич,Сторожук,78Арсен,Калач,65Аскольд,Єрмак,15&Ілля,Миклашевський,96 
        /// Герасим,Боярчук,45(Тарас,Довгалевський,32(Зборислав,Степанець,74Всевлад,Дідух,68Гордій,Ликович,79Назар,Ємець,98
        /// 
        /// Output:
        /// 퀦킆킻톻ⲏ鳐룐뫐믐냐裑뗐닐臑賑뫐룐말㤬ᠶ鷐냐럐냐胑퀬킄킼통톆Ⲍ㠹
        /// 
        /// Input:
        /// FirstName,LastName,Age!Ладо,Кульчицький,8$Добромисл,Трясило,56Кузьма,Іванів,80$Станіслав,Ломовий,15(Лаврентій,Дмитришин,47)
        /// Подолян,Гриневецький,1"Всевлад,Гнатишин,97(Хвалимир,Григоришин,11$Степан,Майстренко,86 Мстислав,Яловий,85
        /// 
        /// Output:
        /// "Всевлад,Гнатишин,97
        static void Main(string[] args) 
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string directory = Path.Combine(Directory.GetCurrentDirectory(), "data");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string source = Path.Combine(directory, "task6.dat");

            FileInfo file = new FileInfo(source);
            ReadFileWithCreatingBinaryOne(file);
            GetUsersByMaximalMark(file);
        }

        static void ReadFileWithCreatingBinaryOne(FileInfo file) 
        {
            string pathToTask4File = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", 
                "Task4", "bin","Debug", "net6.0", "data", "task4.csv");
            using (StreamReader sr = File.OpenText(pathToTask4File))
            {
                string line;

                if (!file.Exists)
                {
                    using (BinaryWriter bw = new BinaryWriter(file.OpenWrite()))
                    {
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            bw.Write(line);
                        }
                    }
                }
            }
        }

        static void GetUsersByMaximalMark(FileInfo file) 
        {
            string resultPath = Path.Combine(Directory.GetCurrentDirectory(), "data", "result.dat");


            using (BinaryReader br = new BinaryReader(file.OpenRead()))
            {
                string str = "";
                str = br.ReadString();
                int count = 0;

                using (BinaryWriter bw = new BinaryWriter(new FileStream(resultPath, FileMode.OpenOrCreate)))
                {

                    while (br.PeekChar() > -1)
                    {
                        string[] userData = new string[3];
                        int level = 0;
                        str = br.ReadString();
                        int i = 0;
                        while (level < 3)
                        {
                            while (i < str.Length && str[i] != ',')
                            {
                                userData[level] += str[i];
                                i++;
                            }
                            level++;
                            i++;
                        }
                        count++;
                        if (Convert.ToInt32(userData[2]) > 95) 
                        {
                            bw.Write(userData[0] + "," + userData[1] + "," + userData[2]);
                        }
                    }

                    bw.Write(count);
                }
            }
        }
    }
}
