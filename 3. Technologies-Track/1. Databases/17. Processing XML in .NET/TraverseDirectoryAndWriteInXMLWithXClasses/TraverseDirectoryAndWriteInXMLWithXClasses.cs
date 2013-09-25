using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

class TraverseDirectoryAndWriteInXMLWithXClasses
{
    static void Main()
    {
        DirectoryInfo root = new DirectoryInfo("../../../");

        XDocument doc = new XDocument();
        XElement dirs = new XElement("Directories");
        doc.Add(dirs);

        TraverseAndWriteInXml(dirs, root);

        doc.Save("../../dirs.xml");
    }

    private static void TraverseAndWriteInXml(XElement parent, DirectoryInfo root)
    {
        XElement child = new XElement("dir");
        child.SetAttributeValue("name", root.Name);

        parent.Add(child);

        foreach (var dir in root.GetDirectories())
        {
            TraverseAndWriteInXml(child, dir);
        }

        foreach (var file in root.GetFiles())
        {
            XElement childFile = new XElement("file", file.Name);
            child.Add(childFile);
        }
    }
}
