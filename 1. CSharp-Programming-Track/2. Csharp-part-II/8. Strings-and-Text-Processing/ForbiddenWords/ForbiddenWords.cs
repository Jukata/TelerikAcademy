//We are given a string containing a list of forbidden words and a text containing some
//of these words. Write a program that replaces the forbidden words with asterisks. Example:
//Microsoft announced its next generation PHP compiler today.
//It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
//		Words: "PHP, CLR, Microsoft"
//		The expected result:
//********* announced its next generation *** compiler today. 
//It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

using System;
using System.Text;
using System.Linq;

class ForbiddenWords
{
    static void Main()
    {
        //note that words mustn't be substrings
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };
        string fixedText = ReplaceForbiddenWords(text, forbiddenWords);
        Console.WriteLine(fixedText);
    }

    private static string ReplaceForbiddenWords(string text, string[] forbiddenWords)
    {
        StringBuilder fixedText = new StringBuilder(text);
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            int index = text.IndexOf(forbiddenWords[i]);
            while (index != -1)
            {
                if (text.Length == forbiddenWords[i].Length)
                {
                    fixedText = fixedText.Replace(forbiddenWords[i], new string('*', forbiddenWords[i].Length));
                }
                else if (index == 0)
                {
                    if (!char.IsLetter(text[index + forbiddenWords[i].Length]))
                    {
                        fixedText = fixedText.Replace(forbiddenWords[i], new string('*', forbiddenWords[i].Length), index, forbiddenWords[i].Length);
                    }
                }
                else if (index == text.Length - forbiddenWords[i].Length)
                {
                    if (!char.IsLetter(text[index - 1]))
                    {
                        fixedText = fixedText.Replace(forbiddenWords[i], new string('*', forbiddenWords[i].Length), index, forbiddenWords[i].Length);
                    }
                }
                else
                {
                    if (!char.IsLetter(text[index + forbiddenWords[i].Length]) && !char.IsLetter(text[index - 1]))
                    {
                        fixedText = fixedText.Replace(forbiddenWords[i], new string('*', forbiddenWords[i].Length), index, forbiddenWords[i].Length);
                    }
                }
                index = text.IndexOf(forbiddenWords[i], index + 1);
            }
        }
        return fixedText.ToString();
    }
}