//Write a program that reads a string from the console and prints all different 
//letters in the string along with information how many times each letter is found. 

using System;

class CountForEveryLetterInSentence
{
    static void Main()
    {
        Console.WriteLine("Enter some text:");
        int[] lettersAppearance = new int['z' - 'A' + 1];
        string inputText = Console.ReadLine();
        for (int i = 0; i < inputText.Length; i++)
        {
            if (Char.IsLetter(inputText[i]))
            {
                lettersAppearance[inputText[i] - 'A']++;
            }
        }
        for (int i = 0; i < lettersAppearance.Length; i++)
        {
            if (lettersAppearance[i] != 0)
            {
                Console.WriteLine("{0} -> {1}", (char)(i + 'A'), lettersAppearance[i]);
            }
        }
    }
}

