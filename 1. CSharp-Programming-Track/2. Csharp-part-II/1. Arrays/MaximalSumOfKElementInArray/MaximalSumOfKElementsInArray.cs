//Write a program that reads two integer numbers N and K and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.
//Note that K elements arent defined in a row.

using System;
using System.Collections.Generic;

class MaximalSumOfKElementsInArray
{
    static void Main()
    {
        //List<int> listArray = new List<int> { 1, 5, 5, 5 };
        Console.Write("Enter N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K = ");
        int k = int.Parse(Console.ReadLine());
        if (k > n)
        {
            Console.WriteLine("K must be lower than N.");
        }
        else
        {
            List<int> listArray = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("ListArray[{0}] = ", i);
                listArray.Add(int.Parse(Console.ReadLine()));
            }
            listArray.Sort();
            long sum = 0;
            for (int i = listArray.Count - 1; i > listArray.Count - 1 - k; i--)
            {
                sum += listArray[i];
            }
            Console.WriteLine("The maximum sum of K elements is = {0}", sum);
        }
    }
}

