//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;
using System.Text;

class DeleteOddLinesFromFile
{
    static void Main()
    {
        int a = 15;
        int b = 10;
        int c = 7;
        Console.WriteLine(a > b ? a > c ? a : c : b > c ? b : c);
        try
        {
            StreamReader reader = new StreamReader(@"../../program.cs");
            StringBuilder strBuilder = new StringBuilder();
            using (reader)
            {
                string inputString = reader.ReadLine();
                int countLines = 1;
                while (inputString != null)
                {
                    if (countLines % 2 != 0)
                    {
                        strBuilder.Append(inputString);
                        strBuilder.Append(Environment.NewLine);
                    }
                    inputString = reader.ReadLine();
                    countLines++;
                }
            }
            StreamWriter writer = new StreamWriter(@"../../program.cs");
            using (writer)
            {
                writer.Write(strBuilder);
            }
            Console.WriteLine("Reading and writing completed.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}