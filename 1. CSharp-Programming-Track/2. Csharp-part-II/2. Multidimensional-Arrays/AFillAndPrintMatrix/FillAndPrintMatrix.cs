//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
// 1 5 9  13
// 2 6 10 14
// 3 7 11 15
// 4 8 12 16

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
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = filler;
                filler++;
            }
        }
        PrintMatrix(matrix, n);

        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        matrix[i, j] = filler;
        //        filler++;
        //    }
        //}
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        Console.Write("{0,3} ",matrix[j, i]);
        //    }
        //    Console.WriteLine();
        //}
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
