using System;
using System.Collections.Generic;
using System.Linq;

class OddOccurrencesOfElements
{
    //  Write a program that extracts from a given sequence of strings
    //all elements that present in it odd number of times. Example:
    //{C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}

    static void Main()
    {
        string[] array = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

        Dictionary<string, int> occurrences = new Dictionary<string, int>();

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
            if (pair.Value % 2 != 0)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}

