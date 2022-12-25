
using System;

namespace Sem_1_Lab_2_Testing
{
    class Program
    {
        static int N = 10;
        static int[,] matrix = new int[N, N];

        static int counter = 0;

        static void Main(string[] args)
        {
            init(N);

            int row = 0;
            int col = 0;

            int enter = ' ';
            while (true)
            {
                print();
                Console.WriteLine("Like you leave the program? If no press: Enter, leave: other key");
                enter = (int)Console.ReadKey().Key;

                if (enter == 13)
                {
                    break;
                }
                Console.Clear();
                do
                {
                    Console.Write("Enter row: ");
                    row = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter col: ");
                    col = Convert.ToInt32(Console.ReadLine());
                }
                while (!(row >= 1 && row <= N) && !(col >= 1 && col <= N));

                open(row, col);
            }

            Console.WriteLine("You have left program! IsPerkulates Value: " + percolates());
        }

        static void init(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        static void open(int row, int col)
        {
            counter++;
            int colIndex = col - 1;
            int rowIndex = row - 1;

            matrix[rowIndex, colIndex] = rowIndex * N + colIndex;

            bool connectedWithRoot = false;

            if (rowIndex + 1 < N && matrix[rowIndex + 1, colIndex] != 0)
            {
                if (root(rowIndex + 1, colIndex) < N)
                {
                    union(rowIndex * N + colIndex, (rowIndex + 1) * N + colIndex);
                    connectedWithRoot = true;
                }
                else connect(1, rowIndex + 1, colIndex);
            }

            if (colIndex + 1 < N && matrix[rowIndex, colIndex + 1] != 0)
            {
                if (!connectedWithRoot && root(rowIndex, colIndex + 1) < N)
                {
                    union(rowIndex * N + colIndex, rowIndex * N + colIndex + 1);
                    connectedWithRoot = true;
                }
                else connect(2, rowIndex, colIndex + 1);
            }

            if (colIndex - 1 >= 0 && matrix[rowIndex, colIndex - 1] != 0)
            {
                if (!connectedWithRoot && root(rowIndex, colIndex - 1) < N)
                {
                    union(rowIndex * N + colIndex, rowIndex * N + colIndex - 1);
                    connectedWithRoot = true;
                }
                else connect(3, rowIndex, colIndex - 1);
            }

            if (rowIndex - 1 >= 0 && matrix[rowIndex - 1, colIndex] != 0)
            {
                if (!connectedWithRoot && root(rowIndex - 1, colIndex) < N)
                {
                    union(rowIndex * N + colIndex, (rowIndex - 1) * N + colIndex);
                }
                else connect(4, rowIndex - 1, colIndex);
            }
        }

        static void connect(int id, int row, int col)
        {
            int currRow = row;
            int currCol = col;
            int last = 0;
            int[] history = new int[N * N];

            switch (id)
            {
                case 1:
                    {
                        history[last] = (currRow - 1) * N + currCol;
                        union(currRow * N + currCol, (currRow - 1) * N + currCol);

                        break;
                    }
                case 2:
                    {
                        union(currRow * N + currCol - 1, currRow * N + currCol);
                        history[last] = currRow * N + currCol - 1;

                        break;
                    }
                case 3:
                    {
                        union(currRow * N + currCol, currRow * N + currCol + 1);
                        history[last] = currRow * N + currCol + 1;

                        break;
                    }
                case 4:
                    {
                        history[last] = (currRow + 1) * N + currCol;
                        union((currRow + 1) * N + currCol, currRow * N + currCol);

                        break;
                    }
            }
            last++;

            bool isTopAlso = false;
            bool isFounded = false;
            do
            {

                bool isEnter = false;
                if ((currRow + 1 < N && matrix[currRow + 1, currCol] != 0
                       && !find(history, (currRow + 1) * N + currCol, last)) && !isTopAlso)
                {

                    union((currRow + 1) * N + currCol, currRow * N + currCol);
                    if (currRow - 1 >= 0 && matrix[currRow - 1, currCol] != 0
                        && (id == 2 || id == 3))
                    {

                        isTopAlso = true;
                    }
                    currRow++;
                    history[last] = currRow * N + currCol;

                    last++;
                    isEnter = true;
                    //continue;
                }


                else if (currCol + 1 < N && matrix[currRow, currCol + 1] != 0
                     && !find(history, currRow * N + currCol + 1, last))
                {
                    union(currRow * N + (currCol + 1), currRow * N + currCol);
                    currCol++;
                    history[last] = currRow * N + currCol;
                    last++;
                    isEnter = true;
                    //continue;
                }

                else if (currCol - 1 >= 0 && matrix[currCol, currCol - 1] != 0
                    && !find(history, currRow * N + currCol - 1, last))
                {
                    union(currRow * N + currCol - 1, currRow * N + currCol);

                    currCol--;

                    history[last] = currRow * N + currCol;
                    last++;
                    isEnter = true;
                    //continue;
                }

                else if (currRow - 1 >= 0 && matrix[currRow - 1, currCol] != 0
                    && !find(history, (currRow - 1) * N + currCol, last))
                {
                    if (isTopAlso)
                    {
                        union((currRow - 1) * N + currCol, currRow * N + currCol);

                    }
                    else
                    {
                        union(currRow * N + currCol, (currRow - 1) * N + currCol);

                    }
                    history[last] = currRow * N + currCol;
                    currRow--;
                    last++;
                    isEnter = true;
                    //continue;
                }

                isFounded = find(history, currRow * N + currCol, last);

                if (isFounded && isTopAlso)
                {
                    isFounded = false;
                    currRow = row;
                    currCol = col;
                    continue;
                }

                if (!isEnter)
                {
                    return;
                }
            }
            while (!isFounded);
        }

        static bool find(int[] arr, int index, int last)
        {
            for (int i = 0; i < last; i++)
            {
                if (arr[i] == index)
                {
                    return true;
                }
            }
            return false;
        }

        static int root(int rowIndex, int colIndex)
        {
            if (rowIndex < 0 ||
                rowIndex >= N ||
                colIndex < 0 ||
                colIndex >= N)
            {
                return -1;
            }

            int val = matrix[rowIndex, colIndex];



            while (val != rowIndex * N + colIndex)
            {
                rowIndex = (val / N);
                colIndex = (val % N);

                val = matrix[rowIndex, colIndex];
            }

            return val;
        }

        /// <param name="p">new item</param>
        /// <param name="q">connected item</param>
        static void union(int p, int q)
        {
            int rowIndex = p / N;
            int colIndex = p % N;

            matrix[rowIndex, colIndex] = q;
        }

        static bool isOpen(int row, int col) => matrix[row - 1, col - 1] != 0;

        static bool isFull(int row, int col)
        {
            int rowIndex = row - 1;
            int colIndex = col - 1;
            bool fully = false;

            int rSame = root(rowIndex, colIndex);
            int rLeft = root(rowIndex, colIndex);
            int rRight = root(rowIndex, colIndex);
            int rTop = root(rowIndex, colIndex);
            int rBottom = root(rowIndex, colIndex);

            if ((rSame < N && rSame >= 0) || (rLeft < N && rLeft >= 0) ||
                (rRight < N && rRight >= 0) || (rTop < N && rTop >= 0) ||
                (rBottom < N && rBottom >= 0))
            {
                fully = true;
            }

            return fully;
        }

        static int numberOfOpenSites()
        {
            return counter;
        }

        static bool percolates()
        {
            for (int i = 0; i < N; i++)
            {
                if (matrix[N - 1, i] != 0)
                {
                    if (root(N - 1, i) < N)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void print()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                    if (matrix[i, j].ToString().Length == 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }


        ///
        /// Unit tests
        /// 

        static void InitialTestMatrix() 
        {
            open(6,3);  
            open(7,3);  
            open(8,3);  
            open(9,3);  
            open(10,3);

            open(6,4);

            open(6,5);
            open(7,5);
            open(8,5);
            open(9,5);
            open(10,5);


            open(1,7);
            open(2,7);
            open(3,7);
            open(4,7);
            open(5,7);
            open(6,7);
            open(7,7);
            
            open(7,6);
        }
        static bool percolates_Unit()
        {
            InitialTestMatrix();
            return percolates() == true;
        }

        static bool root_Unit() 
        {
            InitialTestMatrix();

            int rowIndex = 6;
            int colIndex = 3;

            return root(rowIndex, colIndex) == 6;
        }

        static bool isOpen_Unit() 
        {
            InitialTestMatrix();
            return isOpen(7,3) == true;
        }

        static bool isFull_Unit() 
        {
            InitialTestMatrix();
            return isFull(9, 3) == true;
        }

        static bool numberOfOpenSites_Unit() 
        {
            InitialTestMatrix();
            return numberOfOpenSites() == 19;
        }
    }
}
