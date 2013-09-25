using System;
using System.IO;

class TraverseCWindowsDirectory
{
    private const string extension = ".exe";

    static void Main()
    {
        try
        {
            DirectoryInfo directory = new DirectoryInfo(@"D:\");
            FindAllFiles(directory);
        }
        catch (IOException ioe)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ioe.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    private static void FindAllFiles(DirectoryInfo directory)
    {
        try
        {
            var childDirectories = directory.GetDirectories();
            foreach (var dir in childDirectories)
            {
                FindAllFiles(dir);
            }
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(uae.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        var filesInDirectory = directory.GetFiles();
        foreach (var file in filesInDirectory)
        {
            if (file.Extension == extension)
            {
                Console.WriteLine(file.DirectoryName);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(file.Name);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}

