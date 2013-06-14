using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class MatrixTest
    {
        static void Main()
        {
            Matrix<int> myClassMatrix = new Matrix<int>(5, 5);
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
                    Console.Write(myClassMatrix[i, j] + " ");
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
