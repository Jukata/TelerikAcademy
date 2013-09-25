using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class ExtractAlbumsWithLINQ
{
    static void Main()
    {
        XDocument doc = XDocument.Load("../../catalogue.xml");

        var albums =
            from album in doc.Descendants("album")
            where int.Parse(album.Element("year").Value) < (DateTime.Now.Year - 5)
            select new
                {
                    name = album.Element("name").Value,
                    year = album.Element("year").Value
                };

        foreach (var album in albums)
        {
            Console.WriteLine("{0} -> {1}", album.name, album.year);
        }
    }
}
