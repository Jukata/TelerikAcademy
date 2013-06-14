//Write a program, that reads from the console an array of N integers and an integer K,
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

class LargestNumberWhichIsLowerThanK
{
    static void Main()
    {
        //hardoced input
        //int[] array = { 1, 2, 16, 100, 200 };
        //int k = 17;

        //user input
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter k = ");
        int k = int.Parse(Console.ReadLine());

        Array.Sort(array);
        int indexOfK = Array.BinarySearch(array, k);
        if (array[0] > k)
        {
            Console.WriteLine("There isn't number that is lower than {0}", k);
        }
        else
        {
            if (indexOfK >= 0)
            {
                Console.WriteLine("The biggest number that is <= {0}  is = {1}", k, array[indexOfK]);
            }
            else
            {
                Console.WriteLine("The biggest number that is <= {0}  is = {1}", k, array[-indexOfK - 2]);
            }
        }
    }
}

