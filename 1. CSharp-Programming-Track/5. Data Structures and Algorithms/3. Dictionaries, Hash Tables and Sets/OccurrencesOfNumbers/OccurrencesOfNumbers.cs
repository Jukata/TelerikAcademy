using System;
using System.Collections.Generic;

class OccurrencesOfNumbers
{
    static void Main()
    {
        double[] array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

        Dictionary<double, int> occurrences = new Dictionary<double, int>();

        for (int i = 0; i < array.Length; i++)
        {
            if (occurrences.ContainsKey(array[i]))
            {
                occurrences[array[i]]++;
            }
            else
            {
                occurrences[array[i]] = 1;
            }
        }

        foreach (var pair in occurrences)
        {
            Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
        }
    }
}

