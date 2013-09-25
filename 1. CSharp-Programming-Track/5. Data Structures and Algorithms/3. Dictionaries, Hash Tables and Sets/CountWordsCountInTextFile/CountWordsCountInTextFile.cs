using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class CountWordsCountInTextFile
{
    static void Main()
    {
        char[] separators = new char[] { ' ', '\n', '\r', ',', '.', '!', '?', '@', '-', '+', '=', '*', '/', '\\' };
        string[] words;
        using (StreamReader reader = new StreamReader(@"../../words.txt"))
        {
            words = reader.ReadToEnd().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        Dictionary<string, int> occurrences = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            if (occurrences.ContainsKey(words[i].ToLower()))
            {
                occurrences[words[i].ToLower()]++;
            }
            else
            {
                occurrences[words[i].ToLower()] = 1;
            }
        }

        foreach (var pair in occurrences)
        {
            Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
        }
    }
}

