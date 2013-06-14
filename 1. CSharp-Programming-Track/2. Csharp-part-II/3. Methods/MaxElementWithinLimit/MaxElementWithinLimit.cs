//Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.


using System;


class MaxElementWithinLimit
{
    static void Main()
    {
        //user input
        Console.Write("Enter array length = ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Current array:");
        PrintArray(array);

        SortArrayInAscendingOrder(array);
        Console.WriteLine("Sorted array in ascending order:");
        PrintArray(array);

        SortArrayInDescendingOrder(array);
        Console.WriteLine("Sorted array in descending order:");
        PrintArray(array);
    }

    private static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    private static void SortArrayInAscendingOrder(int[] array)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            int maxElementIndex = FindMaxElementIndex(array, 0, i);
            int maxElement = array[maxElementIndex];
            array[maxElementIndex] = array[i];
            array[i] = maxElement;

        }
    }
    private static void SortArrayInDescendingOrder(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int maxElementIndex = FindMaxElementIndex(array, i, array.Length-1);
            int maxElement = array[maxElementIndex];
            array[maxElementIndex] = array[i];
            array[i] = maxElement;
        }
    }

    static int FindMaxElement(int[] array, int startIndex, int endIndex)
    {
        int maxElement = int.MinValue;
        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
            }
        }
        return maxElement;
    }
    static int FindMaxElementIndex(int[] array, int startIndex, int endIndex)
    {
        int maxElement = int.MinValue;
        int maxElementIndex = -1;
        for (int i = startIndex; i <= endIndex; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
                maxElementIndex = i;
            }
        }
        return maxElementIndex;
    }
}
