using System;

class CombinationsNoDuplicates
{
    //n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[k];

        GenerateCombinateionsNoDuplicates(array, 1, 0, n);
    }

    private static void GenerateCombinateionsNoDuplicates(int[] array, int start, int currentIndex, int n)
    {
        if (currentIndex == array.Length)
        {
            Console.WriteLine(string.Join(", ", array));
            return;
        }

        for (int i = start; i <= n; i++)
        {
            array[currentIndex] = i;
            GenerateCombinateionsNoDuplicates(array, i + 1, currentIndex + 1, n);
        }

    }
}
