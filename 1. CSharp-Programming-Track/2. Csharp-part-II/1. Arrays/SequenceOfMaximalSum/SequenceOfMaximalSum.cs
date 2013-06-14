//Write a program that finds the sequence of maximal sum in given array. Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
//	Can you do it with only one loop (with single scan through the elements of the array)?


using System;

class SequenceOfMaximalSum
{
    static void Main()
    {
        //int[] array = { 8881, -2, 11, -3, 4, -165555, 100, 2, 100, -5, 4 };
        Console.Write("Enter array length: ");
        int length = int.Parse(Console.ReadLine());
        if (length < 1)
        {
            Console.WriteLine("Incorrect input.");
            return;
        }
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("Array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = array[0];
        int startIndex = 0;
        int endIndex = 0;
        int currentSum = array[0];
        int currentStartIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            currentSum += array[i];
            if (currentSum < array[i])
            {
                currentSum = array[i];
                currentStartIndex = i;
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = currentStartIndex;
                endIndex = i;
            }
        }
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}

