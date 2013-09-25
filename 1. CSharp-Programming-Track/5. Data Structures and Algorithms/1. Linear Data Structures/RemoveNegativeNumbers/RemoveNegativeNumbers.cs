using System;
using System.Collections.Generic;

class RemoveNegativeNumbers
{
    static void Main()
    {
        List<int> numbers = new List<int>() { -1, 1, 2, 3, -1, -2, -3, 1, -1 };

        List<int> nonNegativeNumbers = numbers.FindAll(x => x >= 0);

        Console.WriteLine(string.Join(", ", nonNegativeNumbers));
    }
}
