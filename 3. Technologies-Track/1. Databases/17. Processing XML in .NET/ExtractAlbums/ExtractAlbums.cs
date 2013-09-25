using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


class ExtractAlbums
{
    static void Main()
    {

        XmlDocument doc = new XmlDocument();
        doc.Load("../../catalogue.xml");

        XmlElement root = doc.DocumentElement;

        string xpath = "/albums/album[year<" + (DateTime.Now.Year - 5) + "]";

        foreach (XmlNode node in root.SelectNodes(xpath))
        {
            Console.WriteLine("{0} -> {1}", node["name"].InnerXml, node["year"].InnerXml);
        }
    }
}

