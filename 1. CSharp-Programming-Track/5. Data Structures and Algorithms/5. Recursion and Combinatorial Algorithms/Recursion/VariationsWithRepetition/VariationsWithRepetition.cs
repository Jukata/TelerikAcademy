using System;

class VariationsWithRepetition
{
    //Example: n=3, k=2, set = {hi, a, b} =>
    //(hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
    private static string[] words;

    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());

        words = new string[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter words[{0}]: ", i);
            words[i] = Console.ReadLine();
        }

        GenerateVariationsWithRepetitions(new int[k], 0);
    }

    private static void GenerateVariationsWithRepetitions(int[] indices, int currentIndex)
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


        for (int i = 0; i <= indices.Length; i++)
        {
            indices[currentIndex] = i;
            GenerateVariationsWithRepetitions(indices, currentIndex + 1);
        }
    }
}

