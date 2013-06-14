//Write a program that deletes from a text file all words that start with the prefix "test".
//Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;
using System.Text;

class DeleteFromFileWordsWithPrefix
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"../../test.txt");
            StringBuilder strBuilder = new StringBuilder();
            string inputText = "";
            using (reader)
            {
                inputText = reader.ReadLine();
                while (inputText != null)
                {
                    strBuilder.Append(FixText(inputText));
                    strBuilder.Append(Environment.NewLine);
                    inputText = reader.ReadLine();
                }
            }
            StreamWriter writer = new StreamWriter(@"../../result.txt");
            using (writer)
            {
                writer.WriteLine(strBuilder);
            }
            Console.WriteLine("Reading and writing completed.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static string FixText(string inputText)
    {
        //StringBuilder fixedText = new StringBuilder(inputText);
        int startIndex = inputText.IndexOf("test");
        while (startIndex != -1)
        {
            int endIndex = 0;
            if (startIndex == 0)
            {
                for (int i = 4; i < inputText.Length; i++) // start after test
                {
                    if (!char.IsLetter(inputText[i]) && !char.IsDigit(inputText[i]) && inputText[i] != '_')
                    {
                        endIndex = i;
                        break;
                    }
                }
            }
            else
            {
                if (!(char.IsLetter(inputText[startIndex - 1]) || char.IsDigit(inputText[startIndex - 1]) || inputText[startIndex - 1] == '_')) // word start with test
                {
                    for (int i = startIndex + 4; i < inputText.Length; i++)
                    {
                        if (!char.IsLetter(inputText[i]) && !char.IsDigit(inputText[i]) && inputText[i] != '_')
                        {
                            endIndex = i;
                            break;
                        }
                    }
                }
            }
            if (endIndex > startIndex && endIndex < inputText.Length)
            {
                inputText = inputText.Remove(startIndex, endIndex - startIndex);
                startIndex = inputText.IndexOf("test");
            }
            else
            {
                startIndex = inputText.IndexOf("test", startIndex + 1);
            }
        }
        return inputText;
    }
}

