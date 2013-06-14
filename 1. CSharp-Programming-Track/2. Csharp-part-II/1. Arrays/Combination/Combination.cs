//Write a program that reads two numbers N and K and generates 
//all the combinations of K distinct elements from the set [1..N]. Example:
//	N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;

namespace Combination
{
    class Combination
    {
        static void Main(string[] args)
        {
            //hardcoded input
            //int n = 5;
            //int[] array = { 1, 2, 3, 4, 5 };
            //int k = 2;

            //user input
            Console.Write("Enter n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter k = ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];
            CombinationMethod(array, n, 0, 1);
        }

        private static void CombinationMethod(int[] array, int n, int index, int currentNumber)
        {
            if (index == array.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = currentNumber; i <= n; i++)
                {
                    array[index] = i;
                    CombinationMethod(array, n, index + 1, i + 1);
                }
            }
        }
    }
}
