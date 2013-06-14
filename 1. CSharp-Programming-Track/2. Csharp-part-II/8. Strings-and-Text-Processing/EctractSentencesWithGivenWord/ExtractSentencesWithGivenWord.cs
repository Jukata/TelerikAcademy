//Write a program that extracts from a given text all sentences containing given word.
//		Example: The word is "in". The text is:
//We are living in a yellow submarine. We don't have anything else. 
//Inside the submarine is very tight. So we are drinking all the day. 
//We will move out of it in 5 days.
//		The expected result is:
//We are living in a yellow submarine.
//We will move out of it in 5 days.
//Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;

class ExtractSentencesWithGivenWord
{
    static void Main()
    {
        string target = "in";
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < sentences.Length; i++)
        {
            if (IsWordInString(sentences[i], target, false))
            {
                Console.WriteLine(sentences[i].Trim() + ".");
            }
        }
    }

    static bool IsWordInString(string text, string target, bool caseSensitive)
    {
        if (!caseSensitive)
        {
            text = text.ToLower();
            target = target.ToLower();
        }
        int index = text.IndexOf(target);
        while (index != -1)
        {
            if (text.Length == target.Length)
            {
                return true;
            }
            else if (index == 0)
            {
                if (!char.IsLetter(text[index + target.Length]))
                {
                    return true;
                }
            }
            else if (index == text.Length - target.Length)
            {
                if (!char.IsLetter(text[index - 1]))
                {
                    return true;
                }
            }
            else
            {
                if (!char.IsLetter(text[index + target.Length]) && !char.IsLetter(text[index - 1]))
                {
                    return true;
                }
            }
            index = text.IndexOf(target, index + 1);
        }
        return false;
    }
}
