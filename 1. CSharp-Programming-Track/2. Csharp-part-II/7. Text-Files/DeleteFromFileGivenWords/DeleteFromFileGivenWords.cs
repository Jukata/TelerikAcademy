//Write a program that removes from a text file all words listed in given another text file.
//Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;

class DeleteFromFileGivenWords
{
    static void Main()
    {
        try
        {
            List<string> wordsForRemove = new List<string>();
            StreamReader reader = new StreamReader(@"../../words for remove.txt");
            using (reader)
            {
                string input = reader.ReadLine();
                while (input != null)
                {
                    wordsForRemove.Add(input);
                    input = reader.ReadLine();
                }
            }
            foreach (string wordForRemove in wordsForRemove)
            {
                string fixedText = "";
                using (reader = new StreamReader(@"../../test.txt"))
                {
                    string inpuText = reader.ReadToEnd();
                    fixedText = FixText(inpuText, wordForRemove);
                }
                using (StreamWriter writer = new StreamWriter(@"../../test.txt"))
                {
                    writer.WriteLine(fixedText);
                }
            }
            Console.WriteLine("Remove completed");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static string FixText(string inputText, string wordForRemove) // word is sequence ONLY of letters
    {
        int startIndex = inputText.IndexOf(wordForRemove);
        while (startIndex != -1)
        {
            if (startIndex == 0)
            {
                bool isSubstring = char.IsLetter(inputText[startIndex + wordForRemove.Length]);
                if (!isSubstring)
                {
                    inputText = inputText.Remove(startIndex, wordForRemove.Length);
                }
            }
            else
            {
                bool isSubstring = char.IsLetter(inputText[startIndex - 1]) || char.IsLetter(inputText[startIndex + wordForRemove.Length]);
                if (!isSubstring) // word isn't substring
                {
                    inputText = inputText.Remove(startIndex, wordForRemove.Length);
                }
            }
            startIndex = inputText.IndexOf(wordForRemove, startIndex + 1);
        }
        return inputText;
    }
}

