using System;

namespace Pascal_Triangle
{
    class Program
    {
        public static void Main()
        {
            int rows = 10;

            Console.WriteLine("Pascal's triangle");
            for (int i = 0; i < rows; i++)
            {
                for(int l = rows-i; l > 0; l--)
                {
                    Console.Write(" ");
                }
                for(int j = 0; j <= i; j++)
                {
                    int factI = 1;
                    int factJ = 1;
                    int divFactIJ = 1;

                    for(int k = 1; k <= i; k++)
                    {
                        if(k <= j)
                        {
                            factJ *= k;
                        }

                        if(k <= i - j)
                        {
                            divFactIJ *= k;
                        }

                        factI *=k;
                    }


                    if(factI == 0) { factI = 1; }
                    if(factJ == 0) { factJ = 1; }
                    if(divFactIJ == 0) { divFactIJ = 1; }

                    int item = factI / (factJ * divFactIJ);

                    

                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}