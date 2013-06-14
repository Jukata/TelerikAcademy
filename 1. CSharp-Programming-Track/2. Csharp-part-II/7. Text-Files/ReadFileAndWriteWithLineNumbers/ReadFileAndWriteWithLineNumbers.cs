//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.

using System;
using System.IO;

class ReadFileAndWriteWithLineNumbers
{
    static void Main()
    {
        try
        {
            StreamWriter writer = new StreamWriter(@"../../result.txt");
            using (writer)
            {
                StreamReader reader = new StreamReader(@"../../ReadFileAndWriteWithLineNumbers.cs");
                using (reader)
                {
                    string stringForWrite = reader.ReadLine();
                    int lineNumber = 1;
                    while (stringForWrite != null)
                    {
                        writer.WriteLine("Line {0}: {1}", lineNumber, stringForWrite);
                        lineNumber++;
                        stringForWrite = reader.ReadLine();
                    }
                }
            }
            Console.WriteLine("Reading and writing completed.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}