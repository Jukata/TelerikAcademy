using System;

class PermutationsGeneratorWithReps
{
    static void Main()
    {
        int[] array = new int[] { 1, 3, 5, 5 };
        //int[] array = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

        Array.Sort(array);
        PermuteRep(array, 0, array.Length);
    }

    private static void PermuteRep(int[] array, int start, int n)
    {
        Print(array);

        for (int left = n - 2; left >= start; left--)
        {
            for (int right = left + 1; right < n; right++)
            {
                if (array[left] != array[right])
                {
                    int oldValue = array[left];
                    array[left] = array[right];
                    array[right] = oldValue;
                    PermuteRep(array, left + 1, n);
                }
            }

            var firstElement = array[left];
            for (int i = left; i < n - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[n - 1] = firstElement;
        }
    }

    private static void Print(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }
}
