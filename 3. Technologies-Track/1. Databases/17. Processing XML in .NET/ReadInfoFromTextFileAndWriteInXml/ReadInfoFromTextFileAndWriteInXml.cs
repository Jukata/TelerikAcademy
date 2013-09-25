using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

class ReadInfoFromTextFileAndWriteInXml
{
    static void Main()
    {
        StreamReader textReader = new StreamReader("../../personInfo.txt");

        string name;
        string address;
        string phoneNumber;

        using (textReader)
        {
            name = textReader.ReadLine();
            address = textReader.ReadLine();
            phoneNumber = textReader.ReadLine();
        }

        XmlWriter xmlWriter = XmlWriter.Create("../../person.xml");

        using (xmlWriter)
        {
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Person");

            xmlWriter.WriteElementString("name", name);
            xmlWriter.WriteElementString("address", address);
            xmlWriter.WriteElementString("phoneNumber", phoneNumber);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
        }
    }
}
