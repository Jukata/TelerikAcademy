//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 
//Sample input:
//Hi!
//Expected output:
//\u0048\u0069\u0021

using System;

class StringToUnicodeLiteral
{
    static void Main()
    {
        string inputString = "Hi!";
        string unicodeLiteral = "";
        foreach (char symbol in inputString)
        {
            unicodeLiteral = unicodeLiteral + "\\u" + string.Format("{0:X4}", (int)symbol);
        }
        Console.WriteLine(unicodeLiteral);
    }
}
