using System;

class Subsets
{
    //Write a program for generating and printing all subsets of k strings from given set of strings.
    //Example: s = {test, rock, fun}, k=2
    //(test rock),  (test fun),  (rock fun)
    private static string[] words;

    static void Main()
    {
        int n = 5;
        words = new string[5] { "test", "rock", "fun", "goal", "task" };
        int k = 2;

        GenerateSubset(new int[k], 0, 0, n);
    }

    private static void GenerateSubset(int[] indices, int start, int currentIndex, int n)
    {
        if (currentIndex == indices.Length)
        {
            for (int i = 0; i < indices.Length; i++)
            {
                Console.Write(words[indices[i]] + " ");
            }
            Console.WriteLine();
            return;
        }

        for (int i = start; i < n; i++)
        {
            indices[currentIndex] = i;
            GenerateSubset(indices, i + 1, currentIndex + 1, n);

        }
    }
}
