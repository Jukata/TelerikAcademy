//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample" -> "elpmas".

using System;
using System.Linq;
using System.Text;

class ReverseString
{
    static void Main()
    {
        Console.Write("Type some string: ");
        string inputString = Console.ReadLine();
        Console.WriteLine(Reverse(inputString));
    }

    static string Reverse(string inputString)
    {
        char[] reversedString = inputString.ToCharArray();
        Array.Reverse(reversedString);
        return new string(reversedString);
    }
}
