namespace HomeWork1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;


            a = SeedValue("a");
            b = SeedValue("b");
            c = SeedValue("c");
            d = SeedValue("d");

            int tmp = a;

            if (tmp > b)
            { tmp = b; }

            if (tmp > c)
            { tmp = c; }

            if (tmp > d)
            { tmp = d; }


            Console.WriteLine("min value: " + tmp.ToString());
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
