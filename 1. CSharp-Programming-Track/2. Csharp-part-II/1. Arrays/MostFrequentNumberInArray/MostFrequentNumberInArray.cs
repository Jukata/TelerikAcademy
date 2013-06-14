//Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)


using System;
using System.Collections.Generic;

class MostFrequentNumberInArray
{
    static void Main()
    {
        // hardcoded input
        int[] array = { 1, 5, 5, 2, -5, 3, 4, 5, 6, 7, 1, 2, 3, 1, 2, 10, 10, 10,-5,-5,-5,-5,-5 }; // -5 (6 times)

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

        // solution with dict
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (dict.ContainsKey(array[i]))
            {
                dict[array[i]]++;
            }
            else
            {
                dict.Add(array[i], 1);
            }
        }
        int mostFrequentNumber = 0;
        int numberOfAppearance = 0;
        foreach (KeyValuePair<int, int> item in dict)
        {
            if (item.Value > numberOfAppearance)
            {
                numberOfAppearance = item.Value;
                mostFrequentNumber = item.Key;
            }
        }
        Console.WriteLine("Most frequent number is {0} ({1} times)", mostFrequentNumber, numberOfAppearance);

        // Solution without dict -> Sorting array and using code from task 4.
        //Array.Sort(array);
        //int count = 1;
        //int bestCount = 1;
        //int bestElement = array[0];
        //int checker = array[0];
        //for (int i = 1; i < array.Length; i++)
        //{
        //    if (array[i] == checker)
        //    {
        //        count++;
        //    }
        //    else
        //    {
        //        if (count > bestCount)
        //        {
        //            bestCount = count;
        //            bestElement = checker;
        //        }
        //        checker = array[i];
        //        count = 1;
        //    }
        //}
        //if (count > bestCount)
        //{
        //    bestCount = count;
        //    bestElement = checker;
        //}
        //Console.WriteLine("Most frequent number is {0} ({1} times)", bestElement, bestCount);
    }
}

