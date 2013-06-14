//Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ReadFileAndReplaceWholeWordStartWithFinish
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
                    strBuilder.Append(Regex.Replace(inputString, @"\bstart\b", "finish"));
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

