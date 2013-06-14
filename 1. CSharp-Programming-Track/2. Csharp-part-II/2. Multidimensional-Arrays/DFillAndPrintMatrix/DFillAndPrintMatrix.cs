//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
// 1 12 11 10
// 2 13 16 9
// 3 14 15 8
// 4 5  6  7

using System;

class FillAndPrintMatrix
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int filler = 1;
        int row = -1;
        int col = 0;
        int startRow = 0;
        int startCol = 0;
        int endRow = n - 1;
        int endCol = n - 1;
        string direction = "down";
        bool flag = false;

        for (filler = 1; filler <= n * n; filler++)
        {
            if (direction == "down")
            {
                row++;
                if (row > endRow)
                {
                    row--;
                    direction = "right";
                    col++;
                    startCol++;
                }
            }
            else if (direction == "right")
            {
                col++;
                if (col > endCol)
                {
                    col--;
                    direction = "up";
                    row--;
                    endRow--;
                }
            }
            else if (direction == "up")
            {
                row--;
                if (row < startRow)
                {
                    row++;
                    direction = "left";
                    col--;
                    endCol--;
                }
            }
            else // if direction = "left"
            {
                col--;
                if (col < startCol)
                {
                    col++;
                    direction = "down";
                    row++;
                    startRow++;
                }
            }
            matrix[row, col] = filler;
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
