using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            double area1 = 0;
            double pr1 = 0;
            bool is_area_calculated1 = false;
            bool is_pr_calculated1 = false;
            double length1 = 10;
            double width1 = 5;
            PrintPerymeterRectangle(ref is_pr_calculated1, ref pr1, width1, length1);
            PrintAreaRectangle(ref is_area_calculated1, ref area1, width1, length1);
            WhatIsIt("Rectangle");
            Console.WriteLine(IsRectangleAsSquare(width1, length1));


            Console.WriteLine("================");
            double area2 = 0;
            double pr2 = 0;
            bool is_area_calculated2 = false;
            bool is_pr_calculated2 = false;
            double length2 = 5;
            double width2 = 10;
            PrintPerymeterRectangle(ref is_pr_calculated2, ref pr2, width2, length2);
            PrintAreaRectangle(ref is_area_calculated2, ref area2, width2, length2);
            WhatIsIt("Rectangle");
            

            Console.WriteLine("=================");
            double area3 = 0;
            double pr3 = 0;
            bool is_area_calculated3 = false;
            bool is_pr_calculated3 = false;
            double radius3 = 5;
            PrintPerymeterCircle(ref is_pr_calculated3, ref pr3, radius3);
            PrintAreaCircle(ref is_area_calculated3, ref area3, radius3);
            WhatIsIt("Cirlce");
        }

        static double CalculatePerymeterRectangle(double width, double length)
        {
            return 2 * (width + length);
        }

        static double CalculatePerymeterCircle(double radius)
        {
            double PI = 3.14;
            return 2 * PI * radius;
        }

        static double CalculateAreaRectangle(double width, double length)
        {
            return width * length;
        }

        static double CalculateAreaCircle(double radius)
        {
            double PI = 3.14;
            return PI * radius * radius;
        }

        static bool IsRectangleAsSquare(double width, double length)
        {
            return width == length;
        }

        static void WhatIsIt(string figure)
        {
            Console.WriteLine($"I am {figure}");
        }

        static void PrintAreaRectangle(ref bool is_area_calculated, ref double area, double width, double length)
        {
            if (!is_area_calculated)
            {
                is_area_calculated = true;
                area = CalculateAreaRectangle(width, length);
            }

            Console.WriteLine("Square is: " + area);

        }

        static void PrintAreaCircle(ref bool is_area_calculated, ref double area, double radius)
        {
            if (!is_area_calculated)
            {
                is_area_calculated=true;
                area = CalculateAreaCircle(radius);
            }

            Console.WriteLine("Square is: " + area);

        }

        static void PrintPerymeterRectangle(ref bool is_pr_calculated, ref double pr, double width, double length)
        {
            if (!is_pr_calculated)
            {
                is_pr_calculated=true;
                pr = CalculatePerymeterRectangle(width, length);
            }
            Console.WriteLine("Perymeter is: " + pr);
        }

        static void PrintPerymeterCircle(ref bool is_pr_calculated, ref double pr, double radius)
        {
            if (!is_pr_calculated)
            {
                is_pr_calculated = true;
                pr = CalculatePerymeterCircle(radius);
            }
            Console.WriteLine("Perymeter is: " + pr);
        }
    }
}
