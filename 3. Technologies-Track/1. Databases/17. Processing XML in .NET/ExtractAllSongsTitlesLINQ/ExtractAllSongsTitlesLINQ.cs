using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class ExtractAllSongsTitlesLINQ
{
    static void Main()
    {
        XDocument doc = XDocument.Load("../../catalogue.xml");

        var titles =
            from song in doc.Descendants("song")
            select song.Element("title");

        foreach (var title in titles)
        {
            if (title != null)
            {
                Console.WriteLine(title.Value);
            }
        }
    }
}

