//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Text.RegularExpressions;

class ExtractPalindromes
{
    static void Main()
    {
        string text = "Write a program that extracts from a given text all palindromes, e.g. \"ABBA\", \"lamal\", \"exe\"";
        char[] separators = { ' ', '.', ',', '"', '!', '?' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            if (IsPalindrom(words[i]))
            {
                Console.WriteLine(words[i]);
            }
        }
    }

    static bool IsPalindrom(string word)
    {
        if (word.Length < 2)
        {
            return false;
        }
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
}

