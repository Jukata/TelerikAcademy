//Write a program that reads a rectangular matrix of size N x M and 
//finds in it the square 3 x 3 that has maximal sum of its elements.
using System;

class FindMax3x3Sum
{
    static void Main()
    {
        //Hardcoded input
        //int[,] matrix ={
        //                   {0,0,0,0,1,2,3,9,9},
        //                   {0,0,0,0,1,2,3,0,9},
        //                   {0,0,0,0,1,2,3,0,9},
        //                   {0,0,0,0,1,2,3,0,9}
        //               };
        //User input
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter m = ");
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, m];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("matrix[{0},{1}] = ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        //print matrix for user
        Console.Clear();
        Console.WriteLine("The matrix is:");
        PrintMatrix(matrix);
        Console.WriteLine();

        long bestSum = long.MinValue;
        int bestRow = -1;
        int bestCol = -1;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                long curretnSum = 0;
                curretnSum += matrix[row, col];
                curretnSum += matrix[row, col + 1];
                curretnSum += matrix[row, col + 2];
                curretnSum += matrix[row + 1, col];
                curretnSum += matrix[row + 1, col + 1];
                curretnSum += matrix[row + 1, col + 2];
                curretnSum += matrix[row + 2, col];
                curretnSum += matrix[row + 2, col + 1];
                curretnSum += matrix[row + 2, col + 2];

                if (curretnSum > bestSum)
                {
                    bestSum = curretnSum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }
        if (bestRow < 0 || bestCol < 0)
        {
            Console.WriteLine("The matrix hasn't 3x3 square.");
        }
        else
        {
            Console.WriteLine("The elements with best sum = {0} are:", bestSum);
            Console.WriteLine("[ {0,3}, {1,3}, {2,3} ]"
                , matrix[bestRow, bestCol], matrix[bestRow, bestCol + 1], matrix[bestRow, bestCol + 2]);
            Console.WriteLine("[ {0,3}, {1,3}, {2,3} ]"
                , matrix[bestRow + 1, bestCol], matrix[bestRow + 1, bestCol + 1], matrix[bestRow + 1, bestCol + 2]);
            Console.WriteLine("[ {0,3}, {1,3}, {2,3} ]"
                , matrix[bestRow + 2, bestCol], matrix[bestRow + 2, bestCol + 1], matrix[bestRow + 2, bestCol + 2]);
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
