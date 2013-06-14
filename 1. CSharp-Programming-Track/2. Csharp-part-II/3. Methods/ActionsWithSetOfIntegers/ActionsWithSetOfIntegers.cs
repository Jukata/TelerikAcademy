//Write methods to calculate minimum, maximum, average, sum and product
//of given set of integer numbers. Use variable number of arguments.

using System;

class ActionsWithSetOfIntegers
{
    static void Main()
    {
        Console.WriteLine("Min(5, 6, 7, 1, 1, 23) = " + Min(5, 6, 7, 1, 1, 23));
        Console.WriteLine("Min(5, 6, -7,-23) = " + Min(5, 6, -7, -23));
        Console.WriteLine("Max(5, 6, 7, 1, 1, 23) = " + Max(5, 6, 7, 1, 1, 23));
        Console.WriteLine("Max(-3,-3,-4,0) = " + Max(-3,-3,-4,0));
        Console.WriteLine("Average(5, 6, 7, 1, 1) = " + Average(5, 6, 7, 1, 1));
        Console.WriteLine("Average() = " + Average());
        Console.WriteLine("Sum(5, 6, 7, 3, 4, 5) = " + Sum(5, 6, 7, 4, 5));
        Console.WriteLine("Sum(5, -1,-2,-2, 3, 4, 5) = " + Sum(5, -1, -2, -2, 3, 4, 5));
        Console.WriteLine("Product(5, 6, 7, 3, 4, 5) = " + Sum(5, 6, 7, 3, 4, 5));
        Console.WriteLine("Product(5, -1,-2,-2) = " + Sum(5, -1, -2, -2));

    }
    static int Min(params int[] numbers)
    {
        int min = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }
    static int Max(params int[] numbers)
    {
        int max = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
    static double Average(params int[] numbers)
    {
        double sum = 0.0;
        int count = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            count++;
        }
        return sum / count;
    }
    static long Sum(params int[] numbers)
    {
        long sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static long Product(params int[] numbers)
    {
        long product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }
}

