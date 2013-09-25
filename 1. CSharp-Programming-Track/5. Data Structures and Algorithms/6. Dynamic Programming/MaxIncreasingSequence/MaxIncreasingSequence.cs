using System;

class MaxIncreasingSequence
{
    static void Main()
    {
        int[] numbers = { -1, 0, 6, 7, 5, -51, 3, 4, 5 };

        int[] lengths = new int[numbers.Length];
        int[] pointers = new int[numbers.Length];

        for (int i = 0; i < pointers.Length; i++)
        {
            pointers[i] = -1;
        }

        int maxSequenceEndIndex = -1;
        int maxSequenceLenght = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            lengths[i] = 1;
            for (int k = 0; k < i; k++)
            {
                if (numbers[k] < numbers[i])
                {
                    if (lengths[k] + 1 > lengths[i])
                    {
                        lengths[i] = lengths[k] + 1;
                        pointers[i] = k;

                        if (lengths[i] > maxSequenceLenght)
                        {
                            maxSequenceLenght = lengths[i];
                            maxSequenceEndIndex = i;
                        }
                    }
                }
            }
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
}
