using System;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            string sub = "abc";

            string main = "abcabc";

            int[] arr = GetFragmentIndexes(sub, main);

            PrintIndexes(arr);

        }

        static int[] GetFragmentIndexes(string sub, string main)
        {
            for (int i = 0; i < main.Length; i++)
            {
                bool isSame = false;

                bool isDor = main[i] == sub[0];
                bool isCorrect = main.Length - i >= sub.Length;

                if (isDor
                    && isCorrect)
                {
                    int startIndex = i;
                    isSame = true;
                    for (int j = 0; j < sub.Length; j++)
                    {
                        if (main[startIndex + j] != sub[j])
                        {
                            isSame = false;
                            break;
                        }

                    }



                    if (isSame)
                    {
                        string newString = "";
                        if (startIndex + sub.Length < main.Length)
                        {
                            for (int k = startIndex + sub.Length; k < main.Length; k++)
                            {
                                newString += main[k];
                            }


                            int[] retArr = GetFragmentIndexes(sub, newString);
                            int[] newArr = new int[retArr.Count() + 1];

                            for (int l = 0; l < retArr.Length; l++)
                            {
                                newArr[l] = retArr[l] + startIndex + sub.Length;
                            }
                            newArr[retArr.Length] = startIndex;

                            return newArr;
                        }
                        else
                        {
                            return new int[1] { startIndex };
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }


            return new int[0];
        }

        static void PrintIndexes(int[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + ", ");
            }

            if (arr.Length == 0)
            {
                Console.WriteLine("Array is empty!");
            }
        }
    }
}
