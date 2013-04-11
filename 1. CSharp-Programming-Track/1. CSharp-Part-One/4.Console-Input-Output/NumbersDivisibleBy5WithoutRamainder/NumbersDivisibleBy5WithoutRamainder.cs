using System;
//Write a program that reads two positive integer numbers
//and prints how many numbers p exist between them such that
//the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.


class NumbersDivisibleBy5WithoutRamainder
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        int min=Math.Min(firstNumber, secondNumber);
        int max = Math.Max(firstNumber, secondNumber);
        int counter = 0;
        for (int i = min; i <= max; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }
        Console.WriteLine("Numbers that can be divided without a remainder of 5 in interval [{0} - {1}] are {2}.",
            min, max, counter);

    }
}

