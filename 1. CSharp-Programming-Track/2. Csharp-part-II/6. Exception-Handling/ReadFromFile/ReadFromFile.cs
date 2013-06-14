//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
//reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…).
//Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;

class ReadFromFile
{
    static void Main()
    {
        try
        {
            Console.Write("Enter full path to the file: ");
            string path = Console.ReadLine();
            StreamReader reader = new StreamReader(path);
            string fullContent = reader.ReadToEnd();
            reader.Close();
            Console.WriteLine(fullContent);
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Out of memory.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Empty path.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Path not in correct format.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path not in correct format.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The path is too long.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You haven't rights to access this directory.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found.");
        }
        catch (IOException)
        {
            Console.WriteLine("Error while reading/writing.");
        }
        catch (ObjectDisposedException)
        {
            Console.WriteLine("Can't read from closed buffer.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

