//Write a program that reads a text file containing a square matrix of numbers 
//and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N. Each of the
//next N lines contain N numbers separated by space. 
//The output should be a single number in a separate text file. Example:
//4
//2 3 3 4
//0 2 3 4   --> 17
//3 7 1 2
//4 3 3 2

using System;
using System.IO;

class ReadMatrixFromFile
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"../../matrix.txt");
            using (reader)
            {
                int matrixSide = int.Parse(reader.ReadLine());
                int[,] matrix = new int[matrixSide, matrixSide];
                for (int i = 0; i < matrixSide; i++)
                {
                    string[] inputNumber = reader.ReadLine().Split(' ');
                    for (int j = 0; j < inputNumber.Length; j++)
                    {
                        matrix[i, j] = int.Parse(inputNumber[j].ToString());
                    }
                }
                Console.WriteLine("Best landing sum = {0}", CalculateBestLandingSum(matrix, 2, 2));
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static int CalculateBestLandingSum(int[,] matrix, int x, int y)
    {
        int bestSum = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0) - x + 1; i++)
        {
            
            for (int j = 0; j < matrix.GetLength(1) - y + 1; j++)
            {
                int currentSum = 0;
                currentSum += matrix[i, j];
                currentSum += matrix[i + 1, j];
                currentSum += matrix[i, j + 1];
                currentSum += matrix[i + 1, j + 1];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                }
            }

        }
        return bestSum;
    }
}

