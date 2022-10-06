namespace HomeWork1
{
    public class Program
    {
        static void Main(string[] args)
        {

            /// it is not code:  sqrt(p(p-a)(p-b)(p-b))

            int a = 0;
            int b = 0;
            int c = 0;
            bool isValid = true;

            a = SeedValue("a");
            b = SeedValue("b");
            c = SeedValue("c");

            if (a <= 0)
            {
                Console.WriteLine("Sorry, side can't be less than 0 or be 0");
                isValid = false;
            }
            if (b <= 0)
            {
                Console.WriteLine("Sorry, side can't be less than 0 or be 0");
                isValid = false;
            }
            if (c <= 0)
            {
                Console.WriteLine("Sorry, side can't be less than 0 or be 0");
                isValid = false;
            }

            if (isValid)
            {

                double p = (a + b + c) / 2;

                double res = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                Console.WriteLine("area of a triangle: " + res);
            }
        }

        /// <summary>
        /// Function for set value to varible
        /// </summary>
        /// <param name="name">Param for a name of variable</param>
        /// <returns>Entered data</returns>
        static int SeedValue(string name)
        {
            int value = 0;
            Console.Write($"Enter value for {name}: ");
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Type of data is not valid!");
                value = -1;
            }
            return value;
        }



    }
}
