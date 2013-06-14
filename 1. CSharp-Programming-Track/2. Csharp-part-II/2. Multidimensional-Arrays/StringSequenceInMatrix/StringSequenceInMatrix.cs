//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets 
//of several neighbor elements located on the same line, column or diagonal. 
//Write a program that finds the longest sequence of equal strings in the matrix. Example:
// ha  fifi ho hi                |  s  qq s
// fo  ha   hi xx -> ha, ha, ha  |  pp pp s -> s, s, s
// xxx ho   ha xx                |  pp qq s

using System;

class StringSequenceInMatrix
{
    static void Main()
    {
        //hardcoded input
        //string[,] matrix = {
        //                       {"ha","fifi","ho","hi"},
        //                       {"fo","ha","hi","xx"},
        //                       {"xxx","ho","ha","xx"}
        //                   };
        //string[,] matrix = {
        //                       {"s","qq","s"},
        //                       {"pp","pp","s"},
        //                       {"pp","qq","s"}
        //                   };

        //User input
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter m = ");
        int m = int.Parse(Console.ReadLine());
        string[,] matrix = new string[n, m];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("matrix[{0},{1}] = ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
        }

        //print matrix for user
        Console.Clear();
        Console.WriteLine("The matrix is:");
        PrintMatrix(matrix);
        Console.WriteLine();

        int bestCount = 0;
        string bestString = "";
        for (int row = 0; row < matrix.GetLength(0); row++) // check rows
        {
            string checker = matrix[row, 0];
            int count = 1;
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == checker)
                {
                    count++;
                }
                else
                {
                    if (count > bestCount)
                    {
                        bestCount = count;
                        bestString = checker;
                    }
                    count = 1;
                    checker = matrix[row, col];
                }
            }
            if (count > bestCount)
            {
                bestCount = count;
                bestString = checker;
            }
        }

        for (int col = 0; col < matrix.GetLength(1); col++) // check cols
        {
            string checker = matrix[0, col];
            int count = 1;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == checker)
                {
                    count++;
                }
                else
                {
                    if (count > bestCount)
                    {
                        bestCount = count;
                        bestString = checker;
                    }
                    count = 1;
                    checker = matrix[row, col];
                }
            }
            if (count > bestCount)
            {
                bestCount = count;
                bestString = checker;
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++) // check main diagonal
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string checker = matrix[row, col];
                int currentRow = row;
                int currentCol = col;
                bool isTheSame = true;
                int count = 0;
                while (currentRow < matrix.GetLength(0) && currentCol < matrix.GetLength(1) && isTheSame)
                {
                    if (matrix[currentRow, currentCol] == checker)
                    {
                        currentRow++;
                        currentCol++;
                        count++;
                    }
                    else
                    {
                        if (count > bestCount)
                        {
                            bestCount = count;
                            bestString = checker;
                        }
                        isTheSame = false;
                    }
                }
                if (count > bestCount)
                {
                    bestCount = count;
                    bestString = checker;
                }
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++) // check secondary diagonal
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string checker = matrix[row, col];
                int currentRow = row;
                int currentCol = col;
                bool isTheSame = true;
                int count = 0;
                while (currentRow < matrix.GetLength(0) && currentCol >= 0 && isTheSame)
                {
                    if (matrix[currentRow, currentCol] == checker)
                    {
                        currentRow++;
                        currentCol--;
                        count++;
                    }
                    else
                    {
                        if (count > bestCount)
                        {
                            bestCount = count;
                            bestString = checker;
                        }
                        isTheSame = false;
                    }
                }
                if (count > bestCount)
                {
                    bestCount = count;
                    bestString = checker;
                }
            }
        }

        Console.WriteLine("Largest string sequence is:"); // print best string sequence
        Console.Write("{ ");
        for (int i = 1; i < bestCount; i++)
        {
            Console.Write("{0}, ", bestString);
        }
        Console.WriteLine(bestString + " }");
    }

    static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,3} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

