//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
// 1 8 9  16
// 2 7 10 15
// 3 6 11 14
// 4 5 12 13

using System;

class FillAndPrintMatrix
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int filler = 1;

        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = filler;
                    filler++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = filler;
                    filler++;
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
