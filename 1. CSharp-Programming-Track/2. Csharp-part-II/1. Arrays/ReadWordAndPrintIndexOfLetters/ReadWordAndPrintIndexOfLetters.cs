//Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array.


using System;

class ReadWordAndPrintIndexOfLetters
{
    static void Main()
    {
        //char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        //                     'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        //                     'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        //                     'n', 'o','p','q','r','s','t','u','v','w','x','y','z'};
        char[] letters = new char[52];
        for (int i = 0; i < 26; i++)
        {
            letters[i] = (char)('A' + i);
            letters[i + 26] = (char)('a' + i);
        }

        string inputWord = Console.ReadLine();
        foreach (char letter in inputWord)
        {
            if (char.IsUpper(letter))
            {
                Console.WriteLine("letter = {0} -> index = {1}", letter, letter - 'A');
            }
            else if (char.IsLower(letter))
            {
                Console.WriteLine("letter = {0} -> index = {1}", letter, letter - 'a' + 26);
            }
        }

    }
}
