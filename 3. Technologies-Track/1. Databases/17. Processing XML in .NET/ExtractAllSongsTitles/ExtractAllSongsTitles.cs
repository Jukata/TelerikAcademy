using System;
using System.Collections.Generic;
using System.Xml;

class ExtractAllSongsTitles
{
    static void Main()
    {
        XmlReader reader = XmlReader.Create("../../catalogue.xml");

        bool inSongTag = false;
        bool inTitleTag = false;

        while (reader.Read())
        {
            string str = reader.Name;
            if (reader.Name == "song")
            {
                if (!inSongTag)
                {
                    inSongTag = true;
                }
                else
                {
                    inSongTag = false;
                    inTitleTag = false;
                }
            }
            else if (reader.Name == "title")
            {
                if (inSongTag && !inTitleTag)
                {
                    string songTitle = reader.ReadInnerXml();
                    Console.WriteLine(songTitle);
                    inTitleTag = true;
                }
                else
                {
                    inTitleTag = false;
                }
            }
        }
    }
}

