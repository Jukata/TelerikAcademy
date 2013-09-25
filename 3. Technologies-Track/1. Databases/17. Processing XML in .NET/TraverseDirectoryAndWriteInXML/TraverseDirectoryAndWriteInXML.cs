using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

class TraverseDirectoryAndWriteInXML
{
    static void Main()
    {
        DirectoryInfo root = new DirectoryInfo("../../../");

        using (XmlWriter writer = XmlWriter.Create("../../dirs.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Directories");

            TraverseAndWriteInXML(writer, root);

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }

    private static void TraverseAndWriteInXML(XmlWriter writer, DirectoryInfo root)
    {
        writer.WriteStartElement("dir");
        writer.WriteAttributeString("name", root.Name);

        foreach (var dir in root.GetDirectories())
        {
            TraverseAndWriteInXML(writer, dir);
        }

        foreach (var file in root.GetFiles())
        {
            writer.WriteElementString("file", file.Name);
        }

        writer.WriteEndElement();
    }
}

