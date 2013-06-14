//Write a program that encodes and decodes a string using given encryption key (cipher).
//The key consists of a sequence of characters. The encoding/decoding is done by
//performing XOR (exclusive or) operation over the first letter of the string with the first of the key,
//the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Text;

class CodingDecoding
{
    static void Main()
    {
        string cipher = "mission";
        string text = "Some text for encode - Write a program that encodes and decodes a string using given encryption key.";
        Console.WriteLine("Input text = {0}", text);
        string encodedText = Encode(text, cipher);
        Console.WriteLine("Encoded text -> {0}", encodedText);
        string decodedText = Decode(encodedText, cipher);
        Console.WriteLine("Decoded text -> {0}", decodedText);
    }

    static string Encode(string text, string chiper)
    {
        StringBuilder result = new StringBuilder(text.Length);
        for (int i = 0, j = 0; i < text.Length; i++, j++)
        {
            if (j >= chiper.Length)
            {
                j = 0;
            }
            result.Append((char)(text[i] ^ chiper[j]));
        }
        return result.ToString();
    }
    static string Decode(string text, string chiper)
    {
        return Encode(text, chiper);
    }
}
