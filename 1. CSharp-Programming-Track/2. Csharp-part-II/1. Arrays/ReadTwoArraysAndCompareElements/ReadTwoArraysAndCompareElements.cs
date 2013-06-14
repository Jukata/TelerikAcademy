//Write a program that reads two arrays from the console and compares them element by element.

using System;

class ReadTwoArraysAndCompareElements
{
    static void Main()
    {
        Console.Write("Enter first array length = ");
        int firstArrayLength = int.Parse(Console.ReadLine());
        Console.Write("Enter second array length = ");
        int secondArrayLength = int.Parse(Console.ReadLine());

        if (firstArrayLength != secondArrayLength)
        {
            Console.WriteLine("The arrays have not same number of elements -> They wont be equals.");
        }
        else
        {
            int[] firstArray = new int[firstArrayLength];
            int[] secondArray = new int[secondArrayLength];
            bool areEquals = true;
            for (int i = 0; i < firstArrayLength; i++)
            {
                Console.Write("firstArray[{0}]=", i);
                firstArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            for (int i = 0; i < secondArrayLength; i++)
            {
                Console.Write("secondArray[{0}]=", i);
                secondArray[i] = int.Parse(Console.ReadLine());
                if (firstArray[i] != secondArray[i])
                {
                    areEquals = false;
                }
            }
            if (areEquals)
            {
                Console.WriteLine("The arrays are equals.");
            }
            else
            {
                Console.WriteLine("The arrays are not equals.");
            }
        }
    }
}

