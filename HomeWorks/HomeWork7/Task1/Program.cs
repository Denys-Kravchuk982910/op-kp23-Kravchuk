using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 10);
            rect.PrintPerymeter();
            rect.PrintArea();
            rect.WhatIsIt();

            Console.WriteLine(rect.IsRectangleAsSquare());

            Console.WriteLine("================");
            Figure figure = new Rectangle(10, 12);
            figure.PrintArea();
            figure.PrintPerymeter();
            figure.WhatIsIt();

            Console.WriteLine("=================");
            figure = new Circle(10);
            figure.PrintArea();
            figure.PrintPerymeter();
            figure.WhatIsIt();
        }
    }

    class Figure
    {
        protected double area;
        protected double pr;
        protected bool is_area_calculated;
        protected bool is_pr_calculated;

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

        public void PrintArea()
        {
            if (!is_area_calculated)
            {
                CalculateArea();
            }

            Console.WriteLine("Square is: " + area);

        }

        public void PrintPerymeter()
        {
            if (!is_pr_calculated)
            {
                CalculatePerymeter();
            }
            Console.WriteLine("Perymeter is: " + pr);
        }

        protected virtual void CalculateArea()
        {
            throw new NotImplementedException();
        }

        protected virtual void CalculatePerymeter()
        {
            throw new NotImplementedException();
        }

        public virtual void WhatIsIt()
        {
            Console.WriteLine("I am abstract Figure");
        }
    }

    class Rectangle : Figure
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        protected override void CalculateArea()
        {
            this.area = this.length * this.width;
        }

        protected override void CalculatePerymeter()
        {
            this.pr = 2 * (this.length + this.width);
        }

        public bool IsRectangleAsSquare()
        {
            return this.width == this.length;
        }

        public override void WhatIsIt()
        {
            Console.WriteLine("I am Rectangle");
        }
    }

    class Circle : Figure
    {
        private double PI = 3.14;
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }

        protected override void CalculateArea()
        {
            this.area = PI * radius * radius;
        }

        protected override void CalculatePerymeter()
        {
            this.pr = 2 * PI * radius;
        }

        public override void WhatIsIt()
        {
            Console.WriteLine("I am Circle");
        }
    }
}
