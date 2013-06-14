//Write a method that returns the index of the first element in array
//that is bigger than its neighbors, or -1, if there’s no such element.

using System;

class IndexOfFirstElementBiggerThanItsNeighbors
{
    static void Main()
    {
        //hardcoded input
        //int[] array = { 1, 2, 5, 4, 5, 6 };

        //user input
        Console.Write("Enter array length = ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int bestIndex = IsBiggerThanNeighbors(array);
        
        if (bestIndex != -1)
        {
            Console.WriteLine("Index of first element bigger than its neighbors is {0}.", bestIndex);
        }
        else
        {
            Console.WriteLine("There isn't element that is bigger than its neighbors.");
        }
    }

    static int IsBiggerThanNeighbors(int[] array)
    {
        for (int position = 1; position < array.Length - 1; position++)
        {
            bool isBigger = false;

            if (array[position] > array[position + 1] && array[position] > array[position - 1])
            {
                isBigger = true;
            }

            if (isBigger)
            {
                return position;
            }
        }
        return -1;
    }
}

