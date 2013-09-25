using System;
using System.Collections.Generic;

class CountNumbersOccurrences
{
    static void Main()
    {
        int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        Dictionary<int, int> numberOccurrences = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (numberOccurrences.ContainsKey(number))
            {
                numberOccurrences[number]++;
            }
            else
            {
                numberOccurrences.Add(number, 1);
            }
        }

        foreach (var item in numberOccurrences)
        {
            Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
        }
    }
}

