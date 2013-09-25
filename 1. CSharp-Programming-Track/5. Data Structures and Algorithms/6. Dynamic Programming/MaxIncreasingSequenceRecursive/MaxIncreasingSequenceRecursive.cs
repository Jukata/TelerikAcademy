using System;

class MaxIncreasingSequence
{
    static int[] numbers = { -1, 0, 6, 7, 5, -51, 3, 4, 5 };
    static int[] lengths = new int[numbers.Length];
    static int[] pointers = new int[numbers.Length];
    static int maxSequenceEndIndex = -1;
    static int maxSequenceLenght = -1;

    static void Main()
    {
        for (int i = 0; i < pointers.Length; i++)
        {
            pointers[i] = -1;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            CalcLenghts(i);
        }

        int nextIndex = maxSequenceEndIndex;
        string sequence = "";
        while (nextIndex != -1)
        {
            sequence = numbers[nextIndex] + " " + sequence;
            nextIndex = pointers[nextIndex];
        }

        Console.WriteLine(sequence);
    }

    private static void CalcLenghts(int n)
    {
        if (lengths[n] > 0)
        {
            return;
        }

        lengths[n] = 1;
        for (int i = 0; i < n; i++)
        {
            if (numbers[i] < numbers[n])
            {
                CalcLenghts(i);
                if (lengths[i] + 1 > lengths[n])
                {
                    lengths[n] = lengths[i] + 1;
                    pointers[n] = i;
                    if (lengths[n] > maxSequenceLenght)
                    {
                        maxSequenceLenght = lengths[n];
                        maxSequenceEndIndex = n;
                    }
                }
            }
        }
    }
}
