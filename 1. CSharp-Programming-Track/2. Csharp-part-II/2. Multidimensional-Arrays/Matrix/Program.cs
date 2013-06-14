//* Write a class Matrix, to holds a matrix of integers. 
//Overload the operators for adding, subtracting and multiplying of matrices,
//indexer for accessing the matrix content and ToString().

using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix myClassMatrix = new Matrix(5, 5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myClassMatrix[i, j] = i + j;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(myClassMatrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            myClassMatrix += myClassMatrix;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(myClassMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(myClassMatrix);
        }
    }
}
