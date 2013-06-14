//Write a program that finds in given array of integers a sequence of given sum S (if present). 
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}
using System;

class SequenceOfGivenSumInArray
{
    static void Main()
    {
        // hardcoded input
        int[] array = { 4, 3, -2, 2, 1, 4, 2, 5, 8, 2, 1, 5, 5, 5,5 };
        int s = 15;

        // User input        
        //Console.Write("Enter array length: ");
        //int length = int.Parse(Console.ReadLine());
        //if (length < 1)
        //{
        //    Console.WriteLine("Incorrect input.");
        //    return;
        //}
        //int[] array = new int[length];
        //for (int i = 0; i < length; i++)
        //{
        //    Console.Write("Array[{0}] = ", i);
        //    array[i] = int.Parse(Console.ReadLine());
        //}
        //int s = int.Parse(Console.ReadLine());
        int currentSum = 0;
        bool hasSolution = false;
        for (int i = 0; i < array.Length; i++)
        {
            currentSum = 0;
            for (int j = i; j < array.Length; j++)
            {
                currentSum += array[j];
                if (currentSum == s)
                {
                    hasSolution = true;
                    Console.Write("These elements have sum = {0} -> ", s);
                    Console.Write("{");
                    for (int k = i; k < j; k++)
                    {
                        Console.Write(array[k] + ", ");
                    }
                    Console.WriteLine(array[j] + "}");
                }
            }
        }
        if (!hasSolution)
        {
            Console.WriteLine("There isn't a sequence that make sum = {0}.", s);
        }
    }
}

