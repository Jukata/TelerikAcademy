//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class BinaryToHex
{
    static void Main()
    {
        Console.Write("Enter number in binary = ");
        string binNumber = Console.ReadLine();
        Console.WriteLine("Number in binary = " + binNumber);
        string hexNumber = "";
        for (int i = binNumber.Length - 1; i >= 0; i -= 4)
        {
            string appender = "";
            if (i - 3 >= 0) appender += "" + binNumber[i - 3] + binNumber[i - 2] + binNumber[i - 1] + binNumber[i];
            else if (i - 2 >= 0) appender += "0" + binNumber[i - 2] + binNumber[i - 1] + binNumber[i];
            else if (i - 1 >= 0) appender += "00" + binNumber[i - 1] + binNumber[i];
            else
            {
                appender += "000" + binNumber[i];
            }

            switch (appender)
            {
                case "0000": hexNumber += "0"; break;
                case "0001": hexNumber += "1"; break;
                case "0010": hexNumber += "2"; break;
                case "0011": hexNumber += "3"; break;
                case "0100": hexNumber += "4"; break;
                case "0101": hexNumber += "5"; break;
                case "0110": hexNumber += "6"; break;
                case "0111": hexNumber += "7"; break;
                case "1000": hexNumber += "8"; break;
                case "1001": hexNumber += "9"; break;
                case "1010": hexNumber += "A"; break;
                case "1011": hexNumber += "B"; break;
                case "1100": hexNumber += "C"; break;
                case "1101": hexNumber += "D"; break;
                case "1110": hexNumber += "E"; break;
                case "1111": hexNumber += "F"; break;
                default: Console.WriteLine("Error!"); break;
            }
        }
        char[] hexNumberArray = hexNumber.ToCharArray();
        Array.Reverse(hexNumberArray);
        hexNumber = new string(hexNumberArray);
        Console.WriteLine("Number in hexadecimal = " + hexNumber);
    }
}

