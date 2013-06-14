//Write a program that finds the maximal sequence of equal elements in an array.
//		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

using System;

class MaximalSequenceOfEqualElements
{
    static void Main()
    {
        //int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1, 1, 2, 3, 5, 5, 5, 5, 5, 5, 5, 55, 5 };
        Console.Write("Enter array length: ");
        int length = int.Parse(Console.ReadLine());
        if (length < 1)
        {
            Console.WriteLine("Incorrect input.");
            return;
        }
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("Array[{0}] = ",i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int count = 1;
        int bestCount = 1;
        int bestElement = array[0];
        int checker = array[0];
        for (int i = 1; i < length; i++)
        {
            if (array[i] == checker)
            {
                count++;
            }
            else
            {
                if (count > bestCount)
                {
                    bestCount = count;
                    bestElement = checker;
                }
                checker = array[i];
                count = 1;
            }
        }
        if (count > bestCount)
        {
            bestCount = count;
            bestElement = checker;
        }
        Console.Write("Maximal sequence of equal elementes is -> {");
        for (int i = 0; i < bestCount - 1; i++)
        {
            Console.Write(bestElement + ", ");
        }
        Console.WriteLine(bestElement + "}");
    }
}

