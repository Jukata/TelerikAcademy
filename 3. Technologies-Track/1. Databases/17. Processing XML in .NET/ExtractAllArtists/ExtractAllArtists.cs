using System;
using System.Collections.Generic;
using System.Xml;

class ExtractAllArtists
{
    static void Main()
    {
        Dictionary<string, int> artistsAlbums = new Dictionary<string, int>();

        XmlDocument doc = new XmlDocument();

        doc.Load("../../catalogue.xml");

        string xPath = "/albums/album/artist";

        foreach (XmlNode artist in doc.SelectNodes(xPath))
        {
            string artistName = artist.InnerText;

            if (artistsAlbums.ContainsKey(artistName))
            {
                artistsAlbums[artistName]++;
            }
            else
            {
                artistsAlbums.Add(artistName, 1);
            }
        }

        foreach (var artistAlbum in artistsAlbums)
        {
            Console.WriteLine("{0} -> {1} album(s).", artistAlbum.Key, artistAlbum.Value);
        }
    }
}
