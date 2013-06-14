//Write a program that reads from the console a string of maximum 20 characters.
//If the length of the string is less than 20, the rest of the characters should be filled with '*'.
//Print the result string into the console.

using System;


class Read20CharactersFromConsole
{
    static void Main()
    {
        int maxLength = 20;
        Console.WriteLine("Enter some text (max {0} characters):", maxLength);
        string inputString = Console.ReadLine();
        if (inputString.Length > maxLength)
        {
            inputString = inputString.Substring(0, maxLength);
        }
        else
        {
            inputString = inputString + new string('*', maxLength - inputString.Length);
        }
        Console.WriteLine("String = {0}\nLength = {1}", inputString, inputString.Length);
    }
}
