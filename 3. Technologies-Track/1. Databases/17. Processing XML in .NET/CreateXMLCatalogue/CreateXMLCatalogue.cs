using System;
using System.Xml;

public class CreateXMLCatalogue
{
    public static Random rand = new Random();
    public const decimal MAGIC_CONST = 1.42m;

    static void Main()
    {
        //Create a XML file representing catalogue. The catalogue should contain
        //albums of different artists. For each album you should define: name, artist,
        //year, producer, price and a list of songs. Each song should be described by title and duration.

        XmlDocument doc = new XmlDocument();

        XmlWriter writer = XmlWriter.Create("../../catalogue.xml");

        writer.WriteStartDocument();
        writer.WriteStartElement("albums");

        for (int i = 0; i < 10; i++)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", "album name" + i);
            writer.WriteElementString("artist", "artist name" + i);
            writer.WriteElementString("year", DateTime.Now.AddYears(i).Year.ToString());
            writer.WriteElementString("Producer", "producer name" + i);
            writer.WriteElementString("Price", (MAGIC_CONST * i).ToString());

            writer.WriteStartElement("song");

            int songsCount = rand.Next(0, 5);

            for (int j = 0; j < songsCount; j++)
            {
                writer.WriteElementString("title", i + "title" + j);
                writer.WriteElementString("duration", (MAGIC_CONST * i * j).ToString());
            }

            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.WriteEndDocument();

        writer.Close();
        writer.Dispose();
    }
}
