using System;
//* Write a program that reads a positive integer number N (N < 20) from console
//and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
//		Example for N = 4       Example for N = 3
//      1  2  3  4              1  2  3
//      12 13 14 5              8  9  4
//      11 16 15 6              7  6  5
//      10 9  8  7

class PrintSpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        if (n > 0 && n <= 21)
        {
            int[,] spiralMatrix = new int[n, n];
            int rowEnd = n;
            int colEnd = n;
            int rowStart = 0;
            int colStart = 0;
            int row = 0;
            int col = 0;
            string direction = "right";
            int nn = n * n;

            for (int i = 1; i <= nn; i++) // fill matrix
            {
                spiralMatrix[row, col] = i;
                switch (direction)
                {
                    case "right":
                        {
                            col++;
                            if (col == colEnd)
                            {
                                col--;
                                direction = "down";
                                rowStart++;
                                row = rowStart;
                            }
                            break;
                        }
                    case "down":
                        {
                            row++;
                            if (row == rowEnd)
                            {
                                row--;
                                direction = "left";
                                colEnd--;
                                col = colEnd - 1;
                            }
                            break;
                        }
                    case "left":
                        {
                            col--;
                            if (col < colStart)
                            {
                                col++;
                                direction = "up";
                                rowEnd--;
                                row = rowEnd - 1;
                            }
                            break;
                        }
                    case "up":
                        {
                            row--;
                            if (row < rowStart)
                            {
                                row++;
                                direction = "right";
                                colStart++;
                                col = colStart;
                            }
                            break;
                        }
                    default: break;
                }
            }

            for (int i = 0; i < n; i++) // print matrix
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,4}", spiralMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

