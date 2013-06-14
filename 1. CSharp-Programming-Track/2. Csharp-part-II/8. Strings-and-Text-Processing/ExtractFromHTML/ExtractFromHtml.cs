//Write a program that extracts from given HTML file its title (if available), 
//and its body text without the HTML tags. Example:
//<html>
//  <head><title>News</title></head>
//  <body><p><a href="http://academy.telerik.com">Telerik
//    Academy</a>aims to provide free real-world practical
//    training for young people who want to turn into
//    skillful .NET software engineers.</p></body>
//</html>

using System;
using System.Text;

class ExtractFromHtml
{
    static void Main()
    {
        string htmlText = @"<html>
  <head><title>News</title></head>
  <body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>
    aims to provide free real-world practical
    training for young people who want to turn into
    skillful .NET software engineers.</p></body>
</html>";
        StringBuilder extractedText = new StringBuilder();
        int startIndex = htmlText.IndexOf(">", htmlText.IndexOf("<title>"))+1;
        int endIndex = htmlText.IndexOf("</title>");
        if (startIndex != -1 && endIndex != -1)
        {
            extractedText.Append(htmlText.Substring(startIndex, endIndex - startIndex));
            extractedText.Append(Environment.NewLine);
        }
        startIndex = htmlText.IndexOf(">", htmlText.IndexOf("<body>"))+1;
        endIndex = htmlText.IndexOf("<", startIndex);
        while (startIndex != -1 && endIndex != -1)
        {
            extractedText.Append(htmlText.Substring(startIndex, endIndex - startIndex));
            startIndex = htmlText.IndexOf(">", endIndex)+1;
            endIndex = htmlText.IndexOf("<", startIndex);
        }
        Console.WriteLine(extractedText);
    }
}
