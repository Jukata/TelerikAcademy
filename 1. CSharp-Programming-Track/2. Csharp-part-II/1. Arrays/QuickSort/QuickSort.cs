//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;
using System.Linq;

class QuickSort
{
    static void Main()
    {
        int[] array = { 6, 5, 1, 11, 15, 2, 5, -5, 5, -5, 153, -525, 123, -51335, -513, 135, -531 };
        int[] sortedArray = QuickSortMethod(array.ToList()).ToArray(); ;
        foreach (var item in sortedArray)
        {
            Console.WriteLine(item);
        }
    }

    static List<int> QuickSortMethod(List<int> array)
    {
        if (array.Count < 2)
        {
            return array;
        }
        int pivotIndex = array.Count / 2;
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i] < array[pivotIndex])
            {
                leftList.Add(array[i]);
            }
            else if (array[i] > array[pivotIndex])
            {
                rightList.Add(array[i]);
            }
        }
        leftList = QuickSortMethod(leftList);
        rightList = QuickSortMethod(rightList);
        List<int> result = new List<int>();

        result.AddRange(leftList);
        result.Add(array[pivotIndex]);
        result.AddRange(rightList);

        return result;
    }
}

