using System;

namespace Pascal_Triangle
{
    class Program
    {
        public static void Main()
        {
            int rows = 10;
            int val = 1;

            Console.WriteLine("Pascal's triangle");
            for (int i = 0; i < rows; i++)
            {
                //  Відступ
                for (int blank = 1; blank <= rows - i; blank++)
                    Console.Write("  ");


                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || i == 0)
                    {
                        val = 1;
                    }
                    else
                    {
                        //  Формула
                        val = val * (i - j + 1) / j;
                    }

                    string tabulation = "";
                    switch(val.ToString().Length)
                    {
                        case 1: {
                                tabulation = "   ";
                                break; }
                            case 2: { 
                                tabulation = "  ";

                                break; }
                            case 3: { 
                                tabulation = " ";
                                break; }

                    }
                    Console.Write(val + tabulation);
                }
                Console.WriteLine();
            }
        }
    }
}