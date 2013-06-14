//Write a program that concatenates two text files into another text file.

using System;
using System.IO;

class ConcatenateTwoTextFiles
{
    static void Main()
    {
        try
        {
            StreamWriter writer = new StreamWriter(@"../../ConcatenatedFiles.txt", false);
            using (writer)
            {
                StreamReader reader = new StreamReader(@"../../ConcatenateTwoTextFiles.cs");
                using (reader)
                {
                    writer.WriteLine(reader.ReadToEnd());
                }
            }
            writer = new StreamWriter(@"../../ConcatenatedFiles.txt", true);
            using (writer)
            {
                StreamReader reader = new StreamReader(@"../../App.config");
                using (reader)
                {
                    writer.WriteLine(reader.ReadToEnd());
                }
            }
            Console.WriteLine("Reading and writing completed.");
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}