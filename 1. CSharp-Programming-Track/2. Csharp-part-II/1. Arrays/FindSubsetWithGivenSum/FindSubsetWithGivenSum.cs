//* We are given an array of integers and a number S. Write a program to find if there 
//exists a subset of the elements of the array that has a sum S. Example:
//	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)


using System;

class FindSubsetWithGivenSum
{
    static void Main()
    {
        //hardcoded input
        //int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
        //int s = 14;

        //user input
        Console.Write("Enter S = ");
        int s = int.Parse(Console.ReadLine());
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
            for (int j = 0; j < array.Length; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    currentSum += array[j];
                }
            }
            if (currentSum == s)
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
