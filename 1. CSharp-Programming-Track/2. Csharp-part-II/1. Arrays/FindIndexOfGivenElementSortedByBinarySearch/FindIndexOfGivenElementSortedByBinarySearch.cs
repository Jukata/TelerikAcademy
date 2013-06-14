//Write a program that finds the index of given element in a sorted array
//of integers by using the binary search algorithm (find it in Wikipedia).

using System;

namespace FindIndexOfGivenElementSortedByBinarySearch
{
    class FindIndexOfGivenElementSortedByBinarySearch
    {
        static void Main()
        {
            int[] array = { -1, 2, 5, 10, 15 };
            Array.Sort(array); // array must be sorted
            int number = 2;
            if (number < array[0])
            {
                Console.WriteLine("There isnt such element in the array.");
                Console.WriteLine("If there was suck element its index shuould be 0");
                return;
            }
            binarySearch(array, number, 0, array.Length - 1);
        }

        static void binarySearch(int[] array, int number, int min, int max)
        {
            int mid = (min + max) / 2;
            if (min > max)
            {
                Console.WriteLine("There isnt such element in the array.");
                Console.WriteLine("If there was suck element its index shuould be " + mid);
                return;
            }
            if (array[mid] == number)
            {
                Console.WriteLine("Element index is " + mid);
                return;
            }
            else if (number > array[mid])
            {
                binarySearch(array, number, mid + 1, max);
            }
            else // (number < array[mid])
            {
                binarySearch(array, number, min, mid - 1);
            }

        }
    }
}
