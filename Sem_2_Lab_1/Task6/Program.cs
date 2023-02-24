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

            using(BinaryReader br = new BinaryReader(new FileStream(Path.Combine(Directory.GetCurrentDirectory(),
                "data", "result.dat"), FileMode.OpenOrCreate)))
            {
                Console.WriteLine(br.ReadString());
                Console.WriteLine(br.ReadString());
                Console.WriteLine(br.ReadInt32());
            }
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
