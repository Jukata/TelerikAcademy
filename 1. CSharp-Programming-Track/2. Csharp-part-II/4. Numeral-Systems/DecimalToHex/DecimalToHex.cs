//Write a program to convert decimal numbers to their hexadecimal representation.

using System;

class DecimalToHex
{
    static void Main()
    {
        Console.Write("Enter number in decimal = ");
        int decimalNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Number in decimal = " + decimalNumber);
        string remainders = "";
        do
        {
            int remainder = decimalNumber % 16;
            if (remainder < 10)
            {
                remainders += remainder;
            }
            else
            {
                switch (remainder)
                {
                    case 10: remainders += "A"; break;
                    case 11: remainders += "B"; break;
                    case 12: remainders += "C"; break;
                    case 13: remainders += "D"; break;
                    case 14: remainders += "E"; break;
                    case 15: remainders += "F"; break;
                    default: Console.WriteLine("Error!"); break;
                }
            }
            decimalNumber /= 16;
        } while (decimalNumber > 0);
        string hexNumber = "";
        for (int i = remainders.Length - 1; i >= 0; i--)
        {
            hexNumber += remainders[i];
        }
        Console.WriteLine("Number in hexadecimal = " + hexNumber);

    }
}
