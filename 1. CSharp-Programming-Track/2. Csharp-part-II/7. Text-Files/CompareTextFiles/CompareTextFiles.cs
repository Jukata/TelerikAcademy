//Write a program that compares two text files line by line and
//prints the number of lines that are the same and the number of
//lines that are different. Assume the files have equal number of lines.

using System;
using System.IO;

class CompareTextFiles
{
    static void Main()
    {
        try
        {
            StreamReader reader1 = new StreamReader(@"../../CompareTextFiles.cs");
            int equalLines = 0;
            int differentLines = 0;
            using (reader1)
            {
                StreamReader reader2 = new StreamReader(@"../../Program.txt");
                using (reader2)
                {
                    string lineFromFirstFile = reader1.ReadLine();
                    string lineFromSecondFile = reader2.ReadLine();
                    while (lineFromFirstFile != null)
                    {
                        if (lineFromFirstFile == lineFromSecondFile)
                        {
                            equalLines++;
                        }
                        else
                        {
                            differentLines++;
                        }
                        lineFromFirstFile = reader1.ReadLine();
                        lineFromSecondFile = reader2.ReadLine();
                    }
                }
            }
            Console.WriteLine("Between file CompareTextFiles.cs and file Program.cs\nthere is {0} equal lines and {1} different lines.", equalLines, differentLines);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}