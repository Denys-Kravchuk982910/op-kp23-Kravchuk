using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 10);
            PrintPerymeter(rect);
            PrintArea(rect);
            WhatIsIt(rect);

            Console.WriteLine(IsRectangleAsSquare(rect));

            Console.WriteLine("================");
            Figure figure = new Rectangle(10, 12);
            PrintArea(figure);
            PrintPerymeter(figure);
            WhatIsIt(figure);

            Console.WriteLine("=================");
            figure = new Circle(5);
            PrintArea(figure);
            PrintPerymeter(figure);
            WhatIsIt(figure);
        }

        static double CalculatePerymeter(Figure figure)
        {
            if (figure is Rectangle)
            {
                Rectangle item = (Rectangle)figure;
                item.pr = 2 * (item.length + item.width);
                return item.pr;
            }
            else if (figure is Circle) 
            {
                Circle item = (Circle)figure;
                item.pr = 2 * item.radius * item.PI;
                return item.pr;
            }
            return 0;
        }

        static double CalculateArea(Figure figure)
        {
            if (figure is Rectangle)
            {
                Rectangle item = (Rectangle)figure;
                item.area = item.length * item.width;
                return item.area;
            }
            else if (figure is Circle)
            {
                Circle item = (Circle)figure;
                item.area = item.radius * item.radius * item.PI;
                return item.area;
            }
            return 0;
        }

        static bool IsRectangleAsSquare(Rectangle rectangle)
        {
            return rectangle.width == rectangle.length;
        }

        static void WhatIsIt(Figure figure)
        {
            if (figure is Rectangle)
            {
                Console.WriteLine("I am Rectangle");
            }
            else if (figure is Circle)
            {
                Console.WriteLine("I am Circle");
            }
            else 
            {
                Console.WriteLine("I am Figure");
            }
        }

        static void PrintArea(Figure figure)
        {
            if (!figure.is_area_calculated)
            {
                figure.area = CalculateArea(figure);
            }

            Console.WriteLine("Square is: " + figure.area);

        }

        static void PrintPerymeter(Figure figure)
        {
            if (!figure.is_pr_calculated)
            {
                figure.pr = CalculatePerymeter(figure);
            }
            Console.WriteLine("Perymeter is: " + figure.pr);
        }
    }

    class Figure
    {
        public double area;
        public double pr;
        public bool is_area_calculated;
        public bool is_pr_calculated;

        public Figure()
        {
            is_area_calculated = false;
            is_pr_calculated = false;
            area = -1;
            pr = -1;
        }

        public Figure(double area, double pr)
        {
            this.area = area;
            this.pr = pr;
            this.is_area_calculated = true;
            this.is_pr_calculated = true;
        }
    }

    class Rectangle : Figure
    {
        public double length;
        public double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
    }

    class Circle : Figure
    {
        public double PI = 3.14;
        public int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }
    }
}
