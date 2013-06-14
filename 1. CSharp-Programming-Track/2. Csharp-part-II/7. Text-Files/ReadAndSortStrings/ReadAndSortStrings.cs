//Write a program that reads a text file containing a list of strings, 
//sorts them and saves them to another text file. Example:
//	Ivan			George
//	Peter			Ivan
//	Maria			Maria
//	George			Peter

using System;
using System.IO;
using System.Collections.Generic;

class ReadAndSortStrings
{
    static void Main()
    {
        List<string> names = new List<string>();
        try
        {
            StreamReader reader = new StreamReader(@"../../names.txt");
            using (reader)
            {
                string name = reader.ReadLine();
                while (name != null)
                {
                    names.Add(name);
                    name = reader.ReadLine();
                }
            }
            names.Sort();
            StreamWriter writer = new StreamWriter(@"../../Sorted names.txt");
            using (writer)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    writer.WriteLine(names[i]);
                }
            }
            Console.WriteLine("Reading and writing completed.");
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

