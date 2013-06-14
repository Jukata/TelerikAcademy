//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class ReadTextFileAndPrintOddLines
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"../../ReadTextFileAndPrintOddLines.cs");
            using (reader)
            {
                StreamWriter writer = new StreamWriter(@"../../OddLines.txt");
                using (writer)
                {
                    while (reader.ReadLine() != null)
                    {
                        writer.WriteLine(reader.ReadLine());
                    }
                }
            }
            Console.WriteLine("Read and write complete.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}