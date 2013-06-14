//Write methods to calculate minimum, maximum, average, sum and product
//of given set of integer numbers. Use variable number of arguments.

using System;
using System.Collections.Generic;

class ActionsWithSetOfIntegers
{
    static void Main()
    {
        Console.WriteLine("Min(5, 6, 7, 1, 1, 23) = " + Min(5, 6, 7, 1, 1, 23));
        Console.WriteLine("Min(5, 6, -7,-23) = " + Min(5, 6, -7, -23));
        Console.WriteLine("Max(5, 6, 7, 1, 1, 23) = " + Max(5, 6, 7, 1, 1, 23));
        Console.WriteLine("Max(-3,-3,-4,0) = " + Max(-3, -3, -4, 0));
        Console.WriteLine("Average(5, 6, 7, 1, 1) = " + Average(5, 6, 7, 1, 1));
        Console.WriteLine("Average(-1,-2) = " + Average(-1,-2));
        Console.WriteLine("Sum(5, 6, 7, 3, 4, 5) = " + Sum(5, 6, 7, 4, 5));
        Console.WriteLine("Sum(5, -1,-2,-2, 3, 4, 5) = " + Sum(5, -1, -2, -2, 3, 4, 5));
        Console.WriteLine("Product(5, 6, 7, 3, 4, 5) = " + Sum(5, 6, 7, 3, 4, 5));
        Console.WriteLine("Product(5, -1,-2,-2) = " + Sum(5, -1, -2, -2));

    }
    static T Min<T>(params T[]  numbers)
    {
        dynamic min = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }
    static T Max<T>(params T[] numbers)
    {
        dynamic max = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
    static T Average<T>(params T[] numbers)
    {
        dynamic sum = 0;
        int count = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            count++;
        }
        return sum / count;
    }
    static T Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static T Product<T>(params T[] numbers)
    {
        dynamic product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }
}

