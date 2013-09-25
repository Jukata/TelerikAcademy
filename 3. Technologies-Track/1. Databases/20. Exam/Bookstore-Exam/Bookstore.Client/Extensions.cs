using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bookstore.Client
{
    public static class Extensions
    {
        public static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }

        public static string GetAttributeText(this XmlNode node, string attributeName)
        {
            XmlAttribute attribute = node.Attributes[attributeName];

            if (attribute == null)
            {
                return null;
            }
            else
            {
                return attribute.Value;
            }
        }
    }
}
