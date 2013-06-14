//Write a program that reads a string from the console and lists all different 
//words in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;

class CountForEveryWordInSentence
{
    static void Main()
    {
        //string text = Console.ReadLine();
        string text = "Write with a with lists all list all with program, that! reads academy academy integer a string from reads I am          with read write      \n Write a string from the console and lists all different words in the string along with information.";
        char[] separators = { ' ', '.', ',', '!', '?', ':', ';', '\n', '\r', '\t' };
        string[] words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        for (int i = 0; i < words.Length; i++)
        {
            if (wordCount.ContainsKey(words[i]))
            {
                wordCount[words[i]]++;
            }
            else
            {
                wordCount.Add(words[i], 1);
            }
        }
        foreach (KeyValuePair<string, int> item in wordCount)
        {
            Console.WriteLine("{0,-11} -> {1,3}", item.Key, item.Value);
        }
    }
}
