using System;

namespace Task1
{
	class Program
	{
		const int size = 4;
		static void Main(string[] args) 
		{
			/// Зробити зсув масиву з додатковим масивом розміром k
			int k = 3;
			int[] arr = new int[size];

			int[] tempArr = new int[k];

            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }

            if (k > size)
			{
				Console.WriteLine("Error!");
				return;
			}

            //int ind1 = (k-1)- ( i - size + k);
            //int ind2 = size - k - 1 + (size - i);
            //            tempArr[ind1] = arr[ind2];
            for (int i = k-1; i >= 0; i--)
            {
                //int ind = size - i - 1;
                //if(ind < 3)
                //{
                //	tempArr[k -(size-i - 1) - 1] = arr[i];
                //}

                //int ind = size - k + i;
                //tempArr[k - i - 1] = arr[k - i - 1];
                //if (ind <= size - k)
                //{

                //	arr[size - 1 - i] = arr[i];
                //}
                //if (i >= k)
                //{

                //if (size - 1 - i < k)
                //{
                //    tempArr[k - (size - i)] = arr[i];
                //}

                int ind = i - k;
                if (ind < 0)
                {
                    ;
                    arr[i] = tempArr[-ind - 1];
                }
                else 
                {
                    arr[i] = arr[ind];
                
                }

                //}
                //else
                //{
                    //int ind = size - i - k - 1;
                    //if (ind >= 0)
                    //{
                    //    arr[ind] = tempArr[k - ind - 1];
                    //}
                //}

                //if (i < k)
                //{
                //    arr[size - i - 1] = tempArr[size - k - i];
                //}

                //if ()
                //{
                //arr[i] = temp 
                //}
                //arr[i] = arr[i-k];

            }


			//         for (int i = k; i < size; i--)
			//{
			//	arr[i] = arr[i-k];

			//}

			for (int i = 0; i < k; i++)
			{
				Console.WriteLine(tempArr[i]);
			}

			for (int i = 0; i < size; i++)
            {
				Console.Write(arr[i] + ", ");
            }

        }
	}
}
