//* Write a program that reads an array of integers and removes 
//from it a minimal number of elements in such way that the remaining array 
//is sorted in increasing order. Print the remaining sorted array. Example:
//	{6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}


using System;

class RemoevElementsToSortArray
{
    static void Main()
    {
        //Hardcoded input
        //int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 }; // -> {1 3 3 4 5}
        //int[] array = { 3, 3, 4, 2, 3 }; // -> { 3 3 3 }

        //User input
        Console.Write("Enter array length = ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Array[{0}] = ",i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int maxIndex = 1 << array.Length;
        int bestCount = 0;
        int bestBinaryIndex = 0;

        for (int i = 0; i < maxIndex; i++)
        {
            int checker = int.MinValue;
            int count = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if ((i >> j & 1) == 1) // Remove this element.
                {
                    continue;
                }
                if (array[j] >= checker)
                {
                    checker = array[j];
                    count++;
                }
                else
                {
                    count = -1; // is not increasing
                    break;
                }
            }
            if (count > bestCount)
            {
                bestCount = count;
                bestBinaryIndex = i;
            }
        }
        if (bestCount > 1)
        {
            Console.Write("Best increasing array after remove -> { ");
            for (int i = 0; i < array.Length; i++)
            {
                if (!((bestBinaryIndex >> i & 1) == 1))
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine("}");
        }
        else
        {
            Console.WriteLine("There isn't increasing sequence.");
        }

    }
}

