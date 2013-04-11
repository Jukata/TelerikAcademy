using System;

class DeclareTwoStringWithQuotes
{
    static void Main()
    {
        string firstString = "The \"use\" of quotations cause difficulties.";
        Console.WriteLine(firstString);
        string secondString = @"The ""use"" of quotations cause difficulties.";
        Console.WriteLine(secondString);
    }
}

