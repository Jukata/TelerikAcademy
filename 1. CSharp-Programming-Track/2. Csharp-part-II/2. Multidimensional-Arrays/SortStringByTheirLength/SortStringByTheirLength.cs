//You are given an array of strings. Write a method that sorts the array
//by the length of its elements (the number of characters composing them).

using System;

class SortStringByTheirLength
{
    static void Main()
    {
        //hardcoded input
        //string[] array = { "1000", "abc", "abc", "cc", "v", "vvvv","v","","ggggggg" };

        //user input
        Console.Write("Enter array length = ");
        int length = int.Parse(Console.ReadLine());
        string[] array = new string[length];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ",i);
            array[i] = Console.ReadLine();
        }

        Array.Sort(array, (x,y) => x.Length.CompareTo(y.Length));
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("{0,10} -> {1} symbol(s).", array[i],array[i].Length);
        }
    }
}
