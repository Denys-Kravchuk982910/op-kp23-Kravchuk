namespace HomeWork1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x1 = 0;
            int y1 = 0;
            int z1 = 0;

            x1 = SeedValue("X1");
            y1 = SeedValue("Y1");
            z1 = SeedValue("Z1");

            int x2 = 0;
            int y2 = 0;
            int z2 = 0;

            x2 = SeedValue("X2");
            y2 = SeedValue("Y2");
            z2 = SeedValue("Z2");



            double module = Math.Sqrt(Math.Pow((x2 - x1), 2) +
                Math.Pow((y2 - y1), 2) + Math.Pow((z2 - z1), 2));

            Console.WriteLine("Module of vector: " + module);


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
