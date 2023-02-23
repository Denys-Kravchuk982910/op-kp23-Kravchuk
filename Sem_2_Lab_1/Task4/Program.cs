using Bogus;
using System;
using System.Data;
using System.Text;

namespace Task4
{
    /// <summary>
    /// Task 4.
    /// The text file contains the names and surnames of the students and their scores in CSV
    /// format.Display all students whose score is less than 60 points.If such students are absent,
    /// display a message on the screen.
    /// First Name 1, Last Name 1, 59
    /// First Name 2, Last Name 2, 60
    /// First Name 3, Last Name 3, 51
    /// </summary>
    class Program
    {
        static int MAX_ITEMS_IN_STUDENTS_ARRAY = 10;
        static void Main(string[] args) 
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string directory = Path.Combine(Directory.GetCurrentDirectory(), "data");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string source = Path.Combine(directory, "task4.csv");


            FileInfo file = new FileInfo(source);
            FillFile(file);
            DisplayStudentsLessSixtyPoints(file);
        }

        static void FillFile(FileInfo info)
        {
            if (!info.Exists)
            {

                using (TextWriter sw = new StreamWriter(info.Create(), Encoding.UTF8))
                {
                    sw.WriteLine("FirstName,LastName,Age");

                    Faker faker = new Faker("uk");
                    string name;
                    string surname;
                    int age;
                    for (int i = 0; i < MAX_ITEMS_IN_STUDENTS_ARRAY; i++)
                    {
                        var item = faker.Name;
                        name = item.FirstName(Bogus.DataSets.Name.Gender.Male);
                        surname = item.LastName(Bogus.DataSets.Name.Gender.Male);
                        age = faker.Random.Int(0, 100);
                        sw.WriteLine(name + "," + surname + "," + age);
                    }
                }
            }
        }

        static void DisplayStudentsLessSixtyPoints(FileInfo file) 
        {
            using (StreamReader sr = new StreamReader(file.OpenRead()))
            {
                string parameters = sr.ReadLine();
                char line = (char)sr.Read();
                int countOfBadStudents = 0;
                int current = 0;
                string[] userData = new string[3];
                while (!sr.EndOfStream)
                {
                    int i = 0;
                    current = 0;
                    userData[current] = "";

                    while (line != '\n')
                    {
                        if(line == ',')
                        {
                            userData[current] += " "; 
                            current++;
                            userData[current] = "";
                            line = (char)sr.Read();
                           
                            continue;
                        }
                        userData[current] += line;
                        line = (char)sr.Read();
                    }

                    if (Convert.ToInt64(userData[2]) < 60)
                    {
                        Console.WriteLine($"Student {userData[0]} {userData[1]} hasn't enough points to get normal mark!");
                        countOfBadStudents++;
                    }

                    line = (char)sr.Read();
                    
                }

                if (countOfBadStudents == 0)
                {
                    Console.WriteLine("All students have finished semester with enough marks!");
                }
            }
        }
    }

}
