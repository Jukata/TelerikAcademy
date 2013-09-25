using System;

class ZigZagSequences
{
    // http://bgcoder.com/Contest/Practice/59 - Task05

    private static int zigZagCount = 0;

    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        GenerateZigZagSequences(new int[k], new bool[n], 0, n);
        Console.WriteLine(zigZagCount);
    }

    private static void GenerateZigZagSequences(int[] array, bool[] used, int currentIndex, int n)
    {
        if (currentIndex == array.Length)
        {
            zigZagCount++;
            //Console.WriteLine(string.Join(" ", array));
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (!used[i])
            {
                if (currentIndex != 0 && currentIndex % 2 == 0 && array[currentIndex - 1] > i)
                {
                    continue;
                }

                if (currentIndex % 2 != 0 && array[currentIndex - 1] < i)
                {
                    continue;
                }

                used[i] = true;
                array[currentIndex] = i;
                GenerateZigZagSequences(array, used, currentIndex + 1, n);
                used[i] = false;
            }
        }
    }
}