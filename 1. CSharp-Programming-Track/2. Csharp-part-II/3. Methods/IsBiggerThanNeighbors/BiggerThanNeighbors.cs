//Write a method that checks if the element at given position in given 
//array of integers is bigger than its two neighbors (when such exist).

using System;

class BiggerThanNeighbors
{
    static void Main()
    {
        //hardcoded input
        //int[] array = { 1, 2, 3, 4, 5, 6 };
        //int position = 3; // count from 0;

        //user input
        Console.Write("Enter array length = ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Ënter position of number for check = ");
        int position = int.Parse(Console.ReadLine());

        bool isBiggerThanNeighbors = IsBiggerThanNeighbors(array,position);
        if (isBiggerThanNeighbors)
        {
            Console.WriteLine("The number at position {0} is bigger than its neighbors.",position);
        }                                
        else                             
        {                                
            Console.WriteLine("The number at position {0} isn't bigger than its neighbors or hasn't neighboors.",position);
        }
    }

    static bool IsBiggerThanNeighbors(int[] array, int position)
    {
        bool isBigger = false;
        if (position > 0 && position < array.Length - 1)
        {
            if (array[position] > array[position + 1] && array[position] > array[position - 1])
            {
                isBigger = true;
            }
        }
        else
        {
            if (position == 0)
            {
                if (array[position] > array[position + 1])
                {
                    isBigger = true;
                }
            }
            else if (position == array.Length - 1)
            {
                if (array[position] > array[position - 1])
                {
                    isBigger = true;
                }
            }
        }
        return isBigger;
    }
}

