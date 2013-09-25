using System;
using System.Collections.Generic;
using System.Xml;


class ExtractArtistsAlbumsCountDOMParser
{
    static void Main()
    {
        Dictionary<string, int> artistsAlbums = new Dictionary<string, int>();

        XmlDocument doc = new XmlDocument();
        doc.Load("../../catalogue.xml");

        XmlNode root = doc.DocumentElement;

        foreach (XmlNode node in root.ChildNodes)
        {
            XmlNode artistnode = node["artist"];
            if (artistnode != null)
            {
                string artistName = artistnode.InnerXml;

                if (artistsAlbums.ContainsKey(artistName))
                {
                    artistsAlbums[artistName]++;
                }
                else
                {
                    artistsAlbums.Add(artistName, 1);
                }
            }
        }

        foreach (var artistAlbum in artistsAlbums)
        {
            Console.WriteLine("{0} -> {1} album(s).", artistAlbum.Key, artistAlbum.Value);
        }
    }
}
