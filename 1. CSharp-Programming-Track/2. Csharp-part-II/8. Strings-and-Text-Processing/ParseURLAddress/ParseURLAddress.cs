//Write a program that parses an URL address given in the format:
//[protocol]://[server]/[resource]
//and extracts from it the [protocol], [server] and [resource] elements. 
//For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//[protocol] = "http"
//[server] = "www.devbg.org"
//[resource] = "/forum/index.php"


using System;

class ParseURLAddress
{
    static void Main()
    {
        string urlAddress = "http://www.devbg.org/forum/index.php";

        int startIndex = 0;
        int count = urlAddress.IndexOf("://");
        Console.WriteLine("[protocol] = \"{0}\"", urlAddress.Substring(0, count));

        startIndex = urlAddress.IndexOf("://") + 3;
        count = urlAddress.IndexOf("/", startIndex) - startIndex;
        Console.WriteLine("[server] = \"{0}\"", urlAddress.Substring(startIndex, count));

        startIndex = urlAddress.IndexOf("/", startIndex + 1);
        count = urlAddress.Length - startIndex;
        Console.WriteLine("[resource] = \"{0}\"", urlAddress.Substring(startIndex, count));
    }
}

