using System;

class CombinationsWithDuplicates
{
    //n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[k];
        GenerateCombinateionsWithDuplicates(array, 1, 0, n);
    }

    private static void GenerateCombinateionsWithDuplicates(int[] array, int start, int currentIndex, int n)
    {
        if (currentIndex == array.Length)
        {
            Console.WriteLine(string.Join(", ", array));
            return;
        }

        for (int i = start; i <= n; i++)
        {
            array[currentIndex] = i;
            GenerateCombinateionsWithDuplicates(array, i, currentIndex + 1, n);
        }
    }
}