//* Write a program that finds the largest area of equal neighbor 
//elements in a rectangular matrix and prints its size. Example:
// 1 3 2 2 2 4
// 3 3 3 2 4 4
// 4 3 1 2 3 3 ---> 13 threes.
// 4 3 1 3 3 1
// 4 3 3 3 1 1

using System;

class LargestAreaOfEqualElementsInMatrix
{
    static int currentCount = 0;
    static int bestCount = 0;
    static int bestElement;

    static void Main()
    {
        //hardcoded input
        //int[,] matrix = {
        //                    { 1, 3, 2, 2, 2, 4},
        //                    { 3, 3, 3, 2, 4, 4},
        //                    { 4, 3, 1, 2, 3, 3},
        //                    { 4, 3, 1, 3, 3, 1},
        //                    { 4, 3, 3, 3, 1, 1}
        //                };

        //user input
        Console.Write("Enter matrix rows = ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter matrix cols = ");
        int cols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("matrix[{0},{1}] = ",row,col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine();
        PrintMatrix(matrix);
        Console.WriteLine();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentCount = 0;
                FindPath((int[,])matrix.Clone(), row, col);
                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    bestElement = matrix[row, col];
                }
            }
        }
        Console.WriteLine(bestElement + " -> " + bestCount + " times.");
    }

    static void FindPath(int[,] matrix, int row, int col)
    {
        currentCount++;
        int checker = matrix[row, col];
        matrix[row, col] = int.MinValue; // check as visited

        if (row - 1 >= 0 && matrix[row - 1, col] == checker) //search up
        {
            FindPath(matrix, row - 1, col);
        }
        if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == checker) //search right
        {
            FindPath(matrix, row, col + 1);
        }
        if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == checker) //search down
        {
            FindPath(matrix, row + 1, col);
        }
        if (col - 1 >= 0 && matrix[row, col - 1] == checker)//search left
        {
            FindPath(matrix, row, col - 1);
        }
    }

    static void PrintMatrix(int[,] matrix)
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

