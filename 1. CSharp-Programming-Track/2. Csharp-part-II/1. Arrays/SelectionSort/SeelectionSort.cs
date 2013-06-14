//Sorting an array means to arrange its elements in increasing order. 
//Write a program to sort an array. Use the "selection sort" algorithm: 
//Find the smallest element, move it at the first position, 
//find the smallest from the rest, move it at the second position, etc.

using System;

class SeelectionSort
{
    static void Main()
    {
        //int[] array = { -55,0, -51132, 11321, 55353, -3235, -121, 400, 0, 0 };
        //int length = 10;
        Console.Write("Enter array length: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < length-1; i++) // Selection Sort
        {
            int minElementPostion = i;
            for (int j = i+1; j < length; j++)
            {
                if (array[j] < array[minElementPostion])
                {
                    minElementPostion = j;
                }
            }
            if (minElementPostion != i)
            {
                int minElement = array[minElementPostion];
                array[minElementPostion] = array[i];
                array[i] = minElement;
            }
        }
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    //static void Main()
    //{
    //    //int[] array = { 0, 5, 1, 3, 5, -1, 4 };
    //    Console.Write("Enter array length: ");
    //    int length = int.Parse(Console.ReadLine());
    //    int[] array = new int[length];
    //    for (int i = 0; i < length; i++)
    //    {
    //        Console.Write("array[{0}] = ", i);
    //        array[i] = int.Parse(Console.ReadLine());
    //    }

    //    for (int i = 0; i < length; i++) // Selection sort 
    //    {
    //        //int currentMinPosition = FindSmallestElement(i, array.Length);
    //        //int currentMinElement = array[currentMinPosition];
    //        //int firstFree = array[i];
    //        //array[i] = currentMinElement;
    //        //array[currentMinPosition] = firstFree;
    //        MoveSmallestToFirsFreePosition(FindSmallestElementPosition(i, length, array), i, array);
    //    }

    //    for (int i = 0; i < length; i++) // Print sorted
    //    {
    //        Console.WriteLine(array[i]);
    //    }
    //}
    //static void MoveSmallestToFirsFreePosition(int currentMinPosition, int firstFreePosition, int[] array)
    //{
    //    int currentMinElement = array[currentMinPosition];
    //    int firstFree = array[firstFreePosition];
    //    array[firstFreePosition] = currentMinElement;
    //    array[currentMinPosition] = firstFree;
    //}
    //static int FindSmallestElementPosition(int startIndex, int lastIndex, int[] array)
    //{
    //    int min = int.MaxValue;
    //    int minPosition = 0;
    //    for (int i = startIndex; i < lastIndex; i++)
    //    {
    //        if (array[i] < min)
    //        {
    //            min = array[i];
    //            minPosition = i;
    //        }
    //    }
    //    return minPosition;
    //}
}
