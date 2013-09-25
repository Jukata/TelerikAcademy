using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public class ReadCatalogAndCreateAlbum
{
    static void Main()
    {
        using (XmlWriter writer = XmlWriter.Create("../../album.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("albums");

            using (XmlReader reader = XmlReader.Create("../../catalogue.xml"))
            {
                bool inAlbumTag = false;
                string albumName = "";
                string authorName = "";
                while (reader.Read())
                {
                    string nodeName = reader.Name;

                    if (nodeName == "album")
                    {
                        if (!inAlbumTag)
                        {
                            inAlbumTag = true;
                            albumName = "";
                            authorName = "";
                        }
                        else
                        {
                            writer.WriteStartElement("album");
                            writer.WriteAttributeString("name", albumName);
                            writer.WriteElementString("author", authorName);
                            writer.WriteEndElement();
                            inAlbumTag = false;
                        }
                    }
                    else if (inAlbumTag && nodeName == "name")
                    {
                        albumName = reader.ReadInnerXml();
                    }
                    else if (inAlbumTag && nodeName == "artist")
                    {
                        authorName = reader.ReadInnerXml();
                    }
                }
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }
}

