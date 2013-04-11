using System;

class SubsetSum
{
    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long[] numbers = new long[n];
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }
        int maxIndex = 1 << n;
        for (int i = 1; i < maxIndex ; i++)
        {
            long currentSum = 0;
            for (int j = 0; j < n; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    currentSum += numbers[j];
                }
            }
            if (currentSum == s)
            {
                result++;
            }
        }
        Console.WriteLine(result);
    }
}

