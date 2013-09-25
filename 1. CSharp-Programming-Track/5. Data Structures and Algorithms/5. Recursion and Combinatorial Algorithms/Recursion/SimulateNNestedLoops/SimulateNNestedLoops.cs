using System;

class SimulateNNestedLoops
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        SimulateNestedLoops(array, 0);
    }

    private static void SimulateNestedLoops(int[] array, int index)
    {
        if (index  == array.Length)
        {
            Console.WriteLine(string.Join(", ", array));
            return;
        }


        for (int i = 1; i <= array.Length; i++)
        {
            array[index] = i;
            SimulateNestedLoops(array, index + 1);
        }
    }

}

