//Write a program that reverses the words in given sentence.
//Example: "C# is not C++, not PHP and not Delphi!" -> "Delphi not and PHP, not C++ not is C#!".

using System;

class ReverseWordsInSentence
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        Console.WriteLine(sentence);
        Console.WriteLine(ReverseWords(sentence));
    }

    static string ReverseWords(string sentence)
    {
        string[] words = sentence.Split(' ');
        string[] reversed = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            reversed[words.Length - 1 - i] = words[i];
        }

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (IsPunctuation(word[word.Length - 1])) // if last digit of the word is punctuation
            {
                reversed[i] = reversed[i] + word[word.Length - 1]; // move punctuation to its original position
                reversed[words.Length - 1 - i] = reversed[words.Length - 1 - i].Remove(reversed[words.Length - 1 - i].Length - 1); // remove punctuation from its old position
            }
        }
        return string.Join(" ", reversed); ;
    }

    private static bool IsPunctuation(char ch)
    {
        if (ch == '.' || ch == ',' || ch == '!' || ch == '?' || ch == ':' || ch == ';')
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

