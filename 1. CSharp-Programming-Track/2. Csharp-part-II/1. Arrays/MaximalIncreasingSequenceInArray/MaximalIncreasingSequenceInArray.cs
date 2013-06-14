//Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

using System;

class MaximalIncreasingSequenceInArray
{
    static void Main()
    {
        //int[] array = { 3, 2, 3, 4, 2, 2, 4 };
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
        int bestCount = 1;
        int count = 1;
        int startIndex = 0;
        int bestStartIndex = 0;
        int checker = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > checker)
            {
                count++;
                checker = array[i];
            }
            else
            {
                if (count > bestCount)
                {
                    bestCount = count;
                    bestStartIndex = startIndex;
                }
                startIndex = i;
                checker = array[i];
                count = 1;
            }
        }
        if (count > bestCount)
        {
            bestCount = count;
            bestStartIndex = startIndex;
        }
        Console.Write("Maximal increasing sequence is -> {");
        int endIndex = bestStartIndex + bestCount - 1;
        for (int i = bestStartIndex; i < endIndex; i++)
        {
            Console.Write(array[i] + ", ");
        }
        Console.WriteLine(array[endIndex] + "}");
    }
}

