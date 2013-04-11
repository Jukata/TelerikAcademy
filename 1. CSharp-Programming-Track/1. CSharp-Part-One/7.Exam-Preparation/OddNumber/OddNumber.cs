using System;

class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long result = 0;
        for (int i = 0; i < n; i++)
        {
            long inputNumber = long.Parse(Console.ReadLine());
            result ^= inputNumber;
        }
        Console.WriteLine(result);
    }
}

