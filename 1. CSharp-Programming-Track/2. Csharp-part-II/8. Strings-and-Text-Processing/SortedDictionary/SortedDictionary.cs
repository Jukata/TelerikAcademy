//A dictionary is stored as a sequence of text lines containing words and their explanations.
//Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
//.NET – platform for applications from Microsoft
//CLR – managed execution environment for .NET
//namespace – hierarchical organization of classes

using System;

class SortedDictionary
{
    static string[] dictionary =
    {
        ".NET - platform for applications from Microsoft",
        "CLR - managed execution environment for .NET",
        "namespace - hierarchical organization of classes"
    };

    static void Main()
    {


        string target = ".NET";
        Console.WriteLine("{0} - {1}.", target, GetDefinition(target));

        target = "CLR";
        Console.WriteLine("{0} - {1}.", target, GetDefinition(target));

        target = "namespace";
        Console.WriteLine("{0} - {1}.", target, GetDefinition(target));

        target = "class";
        Console.WriteLine("{0} - {1}.", target, GetDefinition(target));

    }

    static string GetDefinition(string target)
    {
        for (int i = 0; i < dictionary.Length; i++)
        {
            string str = dictionary[i];
            int indexOfTarget = dictionary[i].IndexOf(target);
            int indexOfDash = dictionary[i].IndexOf("-");
            if (indexOfTarget != -1 && indexOfTarget < indexOfDash)
            {
                return dictionary[i].Substring(indexOfDash + 2);
            }
        }
        return "Word isn't in the dictionary";
    }
}

