using System;
using System.Collections.Generic;

public class LongestSubsequenceOfEqualNumbers
{
    static void Main()
    {
        List<int> numbers = new List<int>() 
        {
            1,2,2
        };

        var result = GetLongestSubsequenceOfEqualNumbers(numbers);
        Console.WriteLine(string.Join(", ", result));
    }

    public static List<int> GetLongestSubsequenceOfEqualNumbers(List<int> sequence)
    {
        if (sequence == null)
        {
            throw new ArgumentNullException("Sequence can't be null");
        }

        if (sequence.Count == 0)
        {
            return new List<int>();
        }

        int bestSequenceIndex = 0;
        int bestSequenceCount = 0;
        int currentSequenceCount = 1;

        for (int i = 0; i < sequence.Count - 1; i++)
        {
            if (sequence[i] == sequence[i + 1])
            {
                currentSequenceCount++;
            }
            else
            {
                if (currentSequenceCount > bestSequenceCount)
                {
                    bestSequenceCount = currentSequenceCount;
                    bestSequenceIndex = i + 1 - bestSequenceCount;
                }
                currentSequenceCount = 1;
            }
        }

        if (currentSequenceCount > bestSequenceCount)
        {
            bestSequenceCount = currentSequenceCount;
            bestSequenceIndex = sequence.Count - bestSequenceCount;
        }

        List<int> result = sequence.GetRange(bestSequenceIndex, bestSequenceCount);
        return result;
    }
}