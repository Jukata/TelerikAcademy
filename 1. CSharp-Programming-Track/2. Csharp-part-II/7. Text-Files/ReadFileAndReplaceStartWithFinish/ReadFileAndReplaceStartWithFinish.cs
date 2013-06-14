//Write a program that replaces all occurrences of the substring "start" with the substring "finish"
// in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;

class ReadFileAndReplaceStartWithFinish
{
    static void Main()
    {
        try
        {
            StringBuilder strBuilder = new StringBuilder();
            StreamReader reader = new StreamReader(@"../../text.txt");
            using (reader)
            {
                String inputString = reader.ReadLine();
                while (inputString != null)
                {
                    strBuilder.Append(inputString.Replace("start", "finish"));
                    strBuilder.Append("\n");
                    inputString = reader.ReadLine();
                }
            }
            StreamWriter writer = new StreamWriter(@"../../text.txt");
            using (writer)
            {
                writer.WriteLine(strBuilder);
            }
            Console.WriteLine("Reading and writing completed.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

