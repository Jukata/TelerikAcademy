//You are given a text. Write a program that changes the text in all regions surrounded
//by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
//We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//The expected result:
//We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.


using System;
using System.Text;

class UpcaseTags
{
    static void Main()
    {
        string openingTag = "<upcase>";
        string closingTag = "</upcase>";
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Console.WriteLine(Upcase(openingTag, closingTag, text));
    }

    static string Upcase(string openingTag, string closingTag, string text)
    {
        int startIndex = text.IndexOf(openingTag);
        int endIndex = text.IndexOf(closingTag, startIndex + 1); // avoid closing before opening
        while (startIndex != -1 && endIndex != -1)
        {
            string substring = text.Substring(startIndex + openingTag.Length, endIndex - startIndex - openingTag.Length);
            text = text.Replace(substring, substring.ToUpper());
            text = text.Remove(startIndex, openingTag.Length);
            text = text.Remove(endIndex - openingTag.Length, closingTag.Length);
            startIndex = text.IndexOf(openingTag);
            endIndex = text.IndexOf(closingTag);
        }
        return text;
    }
}

