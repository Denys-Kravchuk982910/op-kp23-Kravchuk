using System;
using System.Text;
using Task1.Classes;
using Task1.Tools;
using Task1.UnitTesting;

namespace Task1
{
    class Program
    {
        static void Main(string[] agrs)
        {
            //CustomListUnit listUnit = new CustomListUnit();
            //Console.WriteLine(   listUnit.AddUnit());
            //Console.WriteLine(   listUnit.SetValueUnit());
            //Console.WriteLine(   listUnit.GetValueUnit());


            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            CustomList<SalaryNote> notes = new CustomList<SalaryNote>();

            char c = ' ';

            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor activeColor = ConsoleColor.Red;
            while (true)
            {

                int activePosition = 1;
                while (c != 'q')
                {
                    int counter = 0;
                    using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(),
                        "Resources", "Menu.txt")))
                    {
                        while (!sr.EndOfStream)
                        {
                            counter++;
                            string line = sr.ReadLine();

                            if (activePosition == counter)
                            {
                                Console.BackgroundColor = activeColor;
                            }

                            Console.WriteLine(line);
                            Console.BackgroundColor = background;

                        }
                        Console.WriteLine("======================");
                        Console.WriteLine("S - down; W - up; Q - exit");
                    }

                    c = Console.ReadKey().KeyChar;


                    int code = (int)c;
                    Console.Clear();
                    switch (code)
                    {
                        case 119:
                        case 87:
                            {
                                if (activePosition > 1)
                                {
                                    activePosition--;
                                    break;
                                }
                                activePosition = counter;
                                break;
                            }
                        case 115:
                        case 83:
                            {
                                if (activePosition < counter)
                                {
                                    activePosition++;
                                    break;
                                }

                                activePosition = 1;
                                break;
                            }
                        case 113:
                            {
                                return;
                            }
                        case 13:
                            {
                                if (activePosition == 1)
                                {
                                    Console.Write("surname: ");
                                    string surname = Console.ReadLine();
                                    Console.Write("salary paid: ");
                                    string paid = Console.ReadLine();
                                    Console.Write("delayed salary: ");
                                    string delayed = Console.ReadLine();


                                    SalaryNote salaryNote = new SalaryNote(surname,
                                        Convert.ToDouble(paid), Convert.ToDouble(delayed));
                                    Console.Clear();
                                    Console.WriteLine("Surname | Salary | Delayed | Paid");
                                    Console.WriteLine(salaryNote);
                                    Thread.Sleep(2000);

                                    notes.Add(salaryNote);
                                }

                                if (activePosition == 2)
                                {
                                    Console.WriteLine("Id | Surname | Salary | Delayed | Paid");

                                    for (int i = 0; i < notes.Count; i++)
                                    {
                                        Console.WriteLine((i + 1) + "   " + notes[i]);
                                    }

                                    Console.ReadKey();
                                }

                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                    Console.Clear();
                }
            }
        }
    }
}