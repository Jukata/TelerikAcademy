using System;

class Permutations
{
    //n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}

    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];
        bool[] used = new bool[n];
        GeneratePermutations(array, used, 0, n);
    }

    private static void GeneratePermutations(int[] array, bool[] used, int currentIndex, int n)
    {

        if (currentIndex == array.Length)
        {
            Console.WriteLine(string.Join(", ", array));
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            if (!used[i - 1])
            {
                array[currentIndex] = i;
                used[i - 1] = true;
                GeneratePermutations(array, used, currentIndex + 1, n);
                used[i - 1] = false;
            }
        }
    }
}

