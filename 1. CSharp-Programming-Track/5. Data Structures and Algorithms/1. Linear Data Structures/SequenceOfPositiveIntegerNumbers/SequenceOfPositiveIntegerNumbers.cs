using System;
using System.Collections.Generic;
using System.Linq;

internal class SequenceOfPositiveIntegerNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter sequence of positive integer numbers.\n" +
            "Each number must be on new line. Enter empty line for end.");

        List<int> numbers = new List<int>();

        string inputLine = Console.ReadLine();
        while (inputLine != string.Empty)
        {
            int currentNumber;
            if (int.TryParse(inputLine, out currentNumber))
            {
                numbers.Add(currentNumber);
            }

            inputLine = Console.ReadLine();
        };

        if (numbers.Count > 0)
        {
            Console.WriteLine("Sum = {0}", numbers.Sum());
            Console.WriteLine("Avg = {0}", numbers.Average());
        }
    }
}