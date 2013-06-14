//Write a program that reads a list of words from a file words.txt and finds how many times 
//each of the words is contained in another file test.txt. The result should be written
//in the file result.txt and the words should be sorted by the number of their
//occurrences in descending order. Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class WordsFrequenty
{
    static void Main() 
    {
        // the program is case sensitive (A != a ... Z!=z)
        try
        {
            Dictionary<string, int> wordFrequently = new Dictionary<string, int>();
            string splitChars = " .,\r\n";
            using (StreamReader reader1 = new StreamReader(@"../../words.txt"))
            {
                string[] words = reader1.ReadToEnd().Split(splitChars.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    wordFrequently.Add(words[i], 0);
                    using (StreamReader reader2 = new StreamReader(@"../../test.txt"))
                    {
                        string inputText = reader2.ReadToEnd();
                        int index = inputText.IndexOf(words[i]);
                        while (index != -1)
                        {
                            if (IsWord(inputText, index, words[i].Length))
                            {
                                wordFrequently[words[i]]++;
                            }
                            index = inputText.IndexOf(words[i], index + 1);
                        }
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(@"../../result.txt"))
            {
                foreach (KeyValuePair<string, int> word in wordFrequently.OrderByDescending(key => key.Value))
                {
                    writer.WriteLine("{0} -> {1}", word.Key, word.Value);
                }
            }
            Console.WriteLine("Program finished check the text files.");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static bool IsWord(string text, int index, int wordLength)
    {
        if (index == 0)
        {
            bool isSubstring = char.IsLetter(text[index + wordLength]);
            if (isSubstring)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (index == text.Length - wordLength)
        {
            bool isSubstring = char.IsLetter(text[index - 1]);
            if (isSubstring)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            bool isSubstring = char.IsLetter(text[index - 1]) || char.IsLetter(text[index + wordLength]);
            if (isSubstring)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}

