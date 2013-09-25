using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

class FilesAndFoldersTotalSize
{
    static void Main()
    {
        DirectoryInfo dir = new DirectoryInfo(@"C:\WINDOWS");

        Folder root = GetAllFilesAndFolders(dir);

        BigInteger totalSize = CalculateTotalSize(root);
        Console.WriteLine("Total size = {0} bytes", totalSize);
    }

    private static BigInteger CalculateTotalSize(Folder root)
    {
        BigInteger totalSize = 0;

        foreach (Folder folder in root.ChildFolders)
        {
            totalSize += CalculateTotalSize(folder);
        }

        foreach (File file in root.Files)
        {
            totalSize += file.Size;
        }

        return totalSize;
    }

    private static Folder GetAllFilesAndFolders(DirectoryInfo directory)
    {
        Folder currentFolder = new Folder(directory.Name);
        try
        {
            var directories = directory.GetDirectories();
            foreach (var dir in directories)
            {
                currentFolder.AddFolder(GetAllFilesAndFolders(dir));
            }
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(uae.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        foreach (var file in directory.GetFiles())
        {
            currentFolder.AddFile(new File(file.Name, file.Length));
        }

        return currentFolder;
    }
}