//Write a program that reads a string from the console and replaces 
//all series of consecutive identical letters with a single one.
//Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".


using System;

class ReplaceSequenceOfEqualLettersWithOneLetter
{
    static void Main()
    {
        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            int index = text.IndexOf(text[i].ToString() + text[i]);
            while (index != -1)
            {
                text = text.Replace(text[i].ToString() + text[i], text[i].ToString());
                index = text.IndexOf(text[i].ToString() + text[i]);
            }
        }
        Console.WriteLine(text);
    }
}

