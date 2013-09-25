using System;
using System.Collections.Generic;
using System.IO;
using Wintellect.PowerCollections;

class Phonebook
{
    private static MultiDictionary<string, Entry> PhoneBookByName;
    private static MultiDictionary<Tuple<string, string>, Entry> PhoneBookByNameAndTown;

    static void Main()
    {
        PhoneBookByName = new MultiDictionary<string, Entry>(true);
        PhoneBookByNameAndTown = new MultiDictionary<Tuple<string, string>, Entry>(true);

        using (StreamReader phonesReader = new StreamReader(@"../../Phones.txt"))
        {
            string phoneInfo = phonesReader.ReadLine();
            while (phoneInfo != null)
            {
                ParsePhoneInfo(phoneInfo);
                phoneInfo = phonesReader.ReadLine();
            }
        }

        using (StreamReader commandsReader = new StreamReader(@"../../commands.txt"))
        {
            string command = commandsReader.ReadLine();
            while (command != null)
            {
                List<Entry> enriesFound = ExecuteCommand(command);

                // warning printing can take a long time
                // PrintEntries(command, enriesFound);
                // Console.ReadLine();

                command = commandsReader.ReadLine();

            }
        }
    }

    private static void PrintEntries(string command, List<Entry> enriesFound)
    {
        Console.WriteLine("Command - {0}", command);
        Console.WriteLine("Result:");
        Console.Write(string.Join("\n", enriesFound));
        Console.WriteLine("\nPress Any Key to Continue...");
    }

    private static List<Entry> ExecuteCommand(string command)
    {
        string[] commandParams = ParseCommand(command);

        List<Entry> entriesFound = new List<Entry>();

        if (commandParams.Length == 1)
        {
            var entries = PhoneBookByName[commandParams[0].Trim()];
            foreach (Entry entry in entries)
            {
                entriesFound.Add(entry);
            }
        }
        else if (commandParams.Length == 2)
        {
            Tuple<string, string> nameAndTown = new Tuple<string, string>(commandParams[0].Trim(), commandParams[1].Trim());
            var entries = PhoneBookByNameAndTown[nameAndTown];
            foreach (Entry entry in entries)
            {
                entriesFound.Add(entry);
            }
        }
        else
        {
            throw new ArgumentException("Invalid number of parameters");
        }

        return entriesFound;
    }

    private static string[] ParseCommand(string command)
    {
        if (command == null)
        {
            throw new ArgumentNullException("Command can't be null");
        }

        int openBracketIndex = command.IndexOf('(');
        int closeBracketIndex = command.IndexOf(')');

        if (openBracketIndex < 0 || closeBracketIndex < 0 || openBracketIndex >= closeBracketIndex)
        {
            throw new ArgumentException("Command is not in valid format.");
        }

        int length = closeBracketIndex - openBracketIndex - 1;
        string parametters = command.Substring(openBracketIndex + 1, length);

        string[] commandParams = parametters.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        return commandParams;
    }

    private static void ParsePhoneInfo(string phoneInfo)
    {
        string[] phoneInformation = phoneInfo.Split('|');
        if (phoneInformation.Length != 3)
        {
            throw new ArgumentException("Invalid phone information.");
        }

        string name = phoneInformation[0].Trim();
        string town = phoneInformation[1].Trim();
        string phone = phoneInformation[2].Trim();

        Entry entry = new Entry(name, town, phone);

        PhoneBookByName.Add(name, entry);
        PhoneBookByNameAndTown.Add(new Tuple<string, string>(name, town), entry);
    }
}
