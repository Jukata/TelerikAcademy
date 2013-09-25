using System;

class Dividers
{
    // http://bgcoder.com/Contest/Practice/59 - Task03
    private static char[] inputDigits;
    private static int numWithMinDividers = -1;
    private static int minDividersCount = int.MaxValue;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        inputDigits = new char[n];

        for (int i = 0; i < n; i++)
        {
            inputDigits[i] = Console.ReadLine()[0];
        }

        GenerateNumbers(new int[n], new bool[n], 0);
        Console.WriteLine(numWithMinDividers);
    }

    private static void GenerateNumbers(int[] indices, bool[] used, int currentIndex)
    {
        if (currentIndex == indices.Length)
        {
            int num = ParseToInt(indices);
            CountDividers(num);
            return;
        }

        for (int i = 0; i < indices.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                indices[currentIndex] = i;
                GenerateNumbers(indices, used, currentIndex + 1);
                used[i] = false;
            }
        }
    }

    private static void CountDividers(int num)
    {
        int currendDividersCount = 0;
        for (int i = 1; i < num; i++)
        {
            if (num % i == 0)
            {
                currendDividersCount++;
            }
        }

        if (currendDividersCount == minDividersCount && num < numWithMinDividers)
        {
            numWithMinDividers = num;
        }
        else if (currendDividersCount < minDividersCount)
        {
            minDividersCount = currendDividersCount;
            numWithMinDividers = num;
        }
    }

    private static int ParseToInt(int[] indices)
    {
        string str = "";
        for (int i = 0; i < indices.Length; i++)
        {
            str += inputDigits[indices[i]];
        }
        return int.Parse(str);
    }
}
