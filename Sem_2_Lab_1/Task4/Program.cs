using System;
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

        static void FillFile(FileInfo info)
        {

        }

        static void DisplayStudentsLessSixtyPoints(FileInfo file) 
        {
        
        }
    }
}
