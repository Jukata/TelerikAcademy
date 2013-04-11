using System;
//Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

class PrintNumbersThatArentDivisibleBy5and7
{
    static void Main()
    {
        Console.Write("Enter n:");
        uint n = uint.Parse(Console.ReadLine());
        for (int i = 0; i <= n; i++)
        {
            if (i % 21 == 0)
            {
                continue;
            }
            Console.WriteLine(i);
        }
    }
}

