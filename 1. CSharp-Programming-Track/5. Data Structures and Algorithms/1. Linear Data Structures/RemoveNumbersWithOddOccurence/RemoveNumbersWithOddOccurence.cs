using System;
using System.Collections.Generic;

class RemoveNumbersWithOddOccurence
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

        Dictionary<int, int> occurenceNumbers = GroupNumbersByOccurence(numbers);

        var numbersWithOddOccurence = numbers.FindAll(x => occurenceNumbers[x] % 2 == 0);

        Console.WriteLine(string.Join(", ", numbersWithOddOccurence));
    }

    private static Dictionary<int, int> GroupNumbersByOccurence(List<int> numbers)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (result.ContainsKey(number))
            {
                result[number]++;
            }
            else
            {
                result.Add(number, 1);
            }
        }

        return result;
    }
}

