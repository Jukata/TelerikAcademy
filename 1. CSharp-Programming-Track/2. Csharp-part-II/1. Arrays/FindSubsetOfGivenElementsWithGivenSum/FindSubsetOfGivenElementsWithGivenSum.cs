//* Write a program that reads three integer numbers N, K and S and 
//an array of N elements from the console. Find in the array a subset
//of K elements that have sum S or indicate about its absence.

using System;

class FindSubsetOfGivenElementsWithGivenSum
{
    static void Main()
    {
        //hardcoded input
        //int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
        //int s = 14;
        //int k = 5;

        //user input
        Console.Write("Enter S = ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Enter K = ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter array length = ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        //solution
        int maxIndex = 1 << array.Length;
        bool hasAnswer = false;

        for (int i = 1; i < maxIndex; i++)
        {
            int currentSum = 0;
            int currentSequence = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    currentSum += array[j];
                    currentSequence++;
                }
            }
            if (currentSum == s && currentSequence == k)
            {
                hasAnswer = true;
                Console.Write("Yes -> " + "( ");
                for (int j = 0; j < array.Length; j++)
                {
                    if ((i >> j & 1) == 1)
                    {
                        Console.Write(array[j] + " ");
                    }
                }
                Console.WriteLine(")");
            }
        }
        if (!hasAnswer)
        {
            Console.WriteLine("No");
        }
    }
}

