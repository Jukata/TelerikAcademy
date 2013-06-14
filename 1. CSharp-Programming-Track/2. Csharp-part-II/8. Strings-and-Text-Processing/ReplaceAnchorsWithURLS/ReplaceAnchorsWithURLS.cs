//Write a program that replaces in a HTML document given as string all the tags 
//<a href="…">…</a> with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
//<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.
//Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
//Result:
//<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course.
//Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

using System;
using System.Text;

class ReplaceAnchorsWithURLS
{
    static void Main()
    {
        string text = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        text = text.Replace("</a>", "[/URL]");
        StringBuilder fixedText = new StringBuilder(text);
        int startIndex = text.IndexOf("<a");
        int endIndex = text.IndexOf(">", startIndex);
        while (startIndex != -1 && endIndex != -1)
        {
            fixedText[endIndex] = ']';
            fixedText.Replace("\"", "", startIndex, endIndex - startIndex);
            fixedText.Replace("<a href", "[URL", startIndex, endIndex - startIndex);
            text = fixedText.ToString();
            startIndex = text.IndexOf("<a");
            endIndex = text.IndexOf(">", startIndex + 1);
        }
        Console.WriteLine(fixedText);
    }
}
