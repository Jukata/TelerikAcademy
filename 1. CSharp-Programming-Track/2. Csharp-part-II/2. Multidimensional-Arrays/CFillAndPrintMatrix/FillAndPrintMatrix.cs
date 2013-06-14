//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
// 7 11 14 16
// 4 8  12 15
// 2 5  9  13
// 1 3  6  10

using System;

class FillAndPrintMatrix
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int filler = 1;
        int row = n - 1;
        int col = 0;
        for (filler = 1; filler <= n * n; filler++)
        {

            matrix[row, col] = filler;
            row++;
            col++;
            if (row == n || col == n)
            {
                row--;
                while (row != 0 && col != 0)
                {
                    row--;
                    col--;
                }
            }
        }
        PrintMatrix(matrix, n);
    }

    static void PrintMatrix(int[,] matrix, int n)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,3} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
