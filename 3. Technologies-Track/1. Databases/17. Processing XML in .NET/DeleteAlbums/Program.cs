using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

class DeleteAlbums
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();

        doc.Load("../../catalogue.xml");

        XmlNode root = doc.DocumentElement;

        for (int i = 0; i < root.ChildNodes.Count; i++)
        {
            decimal price = decimal.Parse(root.ChildNodes[i]["Price"].InnerXml);

            if (price > 20)
            {
                root.RemoveChild(root.ChildNodes[i]);
                i--; // ninja fix
            }
        }

        doc.Save("../../catalogue.xml");
    }
}

