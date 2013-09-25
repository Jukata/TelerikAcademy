using System;
using Wintellect.PowerCollections;
//A large trade company has millions of articles, each described by barcode, vendor, title and price. 
//Implement a data structure to store them that allows fast retrieval of all articles 
//in given price range [x…y].
//Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 

class Program
{
    static void Main()
    {
        OrderedMultiDictionary<decimal, Article> articles = new OrderedMultiDictionary<decimal, Article>(true);

        articles.Add(100, new Article("124", "EA", "FIFA2012", 100));
        articles.Add(50, new Article("354", "EA", "FIFA2006", 50));
        articles.Add(40, new Article("567", "EA", "FIFA2005", 40));
        articles.Add(110, new Article("57", "EA", "FIFA2013", 110));
        articles.Add(60, new Article("578", "EA", "FIFA2010", 60));
        articles.Add(30, new Article("58", "EA", "FIFA2002", 30));

        foreach (var item in articles.Range(50, true, 60, true))
        {
            Console.WriteLine("{0} -> {1}", item.Key, string.Join(", ", item.Value));
        }
    }
}
