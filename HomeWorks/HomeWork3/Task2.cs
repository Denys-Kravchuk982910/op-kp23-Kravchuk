using System;
using System.Reflection.Emit;

namespace HomeWork3
{
    class Task2
    {
        static void Main(string[] args)
        {
            int levelOfTree = 4;

            int level = 11;
            int triangelsSum = levelOfTree;
            int separator = (triangelsSum * 2) - 2;

            for (int q = 0; q < levelOfTree; q++)
            {
                CreateLevelOfTree(level, separator);
                level += 4;
                triangelsSum -= 1;
                separator = (triangelsSum * 2) - 2;
            }


            level -= 4;
            for (int q = 0; q < levelOfTree; q++)
            {

                for (int i = 0; i < ((level + 1) / 2) - 2; i++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine("***");

            }
        }


        static void CreateLevelOfTree(int level, int separator)
        {
            for (int i = 0; i < level; i += 4)
            {
                for (int j = 0; j < ((level - i) / 2) + separator; j++)
                {
                    Console.Write(" ");
                }
                for (int j = level - i; j <= level; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
