using System;
using System.Collections.Generic;

class SortInputIntegersSequence
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

        numbers.Sort();
        Console.WriteLine("Sorted numbers:");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
