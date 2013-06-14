//Write a program that extracts from given XML file all the text without the tags. Example:
//<?xml version="<<"><student><name>Pesho</name><age>21</age>
//<interests count="3"><interest> G""a""mes</instrest><interest>C#</instrest>
//<interest> Java</instrest></interests></student>

using System;
using System.IO;
using System.Text;

class ExtractWordsFromXMFile
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"../../document.xml");
            StringBuilder strBuilder = new StringBuilder();
            string fullText = "";
            using (reader)
            {
                fullText = reader.ReadToEnd();
            }
            bool quotes = false;
            bool tags = false;
            for (int i = 0; i < fullText.Length; i++)
            {
                if (fullText[i] == '\"' && !tags)
                {
                    quotes = !quotes;
                }
                else if (fullText[i] == '<' && !quotes)
                {
                    tags = true;
                }
                else if (fullText[i] == '>' && !quotes)
                {
                    tags = false;
                }
                else if (!quotes && !tags)
                {
                    strBuilder.Append(fullText[i]);
                }
            }
            Console.WriteLine(strBuilder);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

