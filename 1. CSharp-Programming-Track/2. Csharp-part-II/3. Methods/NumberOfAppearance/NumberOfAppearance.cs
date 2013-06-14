//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is working correctly.

using System;

public class NumberOfAppearance
{
    static void Main()
    {
        //hardcoded input
        //int[] array = { 1, 2, 3, 4, 1, 2, 3, 5, 12, 213, 5, -1, 5, 0, 1, -2, -5,1 };
        //int numberForCheck = 1;

        //userinput
        Console.Write("Enter array length = ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("array[{0}] = ",i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Ënter number for check = ");
        int numberForCheck = int.Parse(Console.ReadLine());
        int numberOfAppearance = CheckNumberOfAppearance(array, numberForCheck);
        Console.WriteLine("The number {0} appear {1} time(s)", numberForCheck, numberOfAppearance);
    }

    public static int CheckNumberOfAppearance(int[] array, int numberForCheck)
    {
        int numberOfAppearance = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (numberForCheck == array[i])
            {
                numberOfAppearance++;
            }
        }
        return numberOfAppearance;
    }
}

