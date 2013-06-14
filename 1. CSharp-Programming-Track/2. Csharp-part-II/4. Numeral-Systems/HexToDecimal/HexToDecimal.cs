//Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexToDecimal
{
    static void Main()
    {
        Console.Write("Enter number in hexadecimal = ");
        string hexNumber = Console.ReadLine();
        hexNumber = hexNumber.ToUpper(); // to avoid lower letter case
        int decimalNumber = 0;
        for (int i = hexNumber.Length - 1, j = 0; i >= 0; i--, j++)
        {
            switch (hexNumber[i])
            {
                case '0': decimalNumber += 0 * Pow(16, j); break;
                case '1': decimalNumber += 1 * Pow(16, j); break;
                case '2': decimalNumber += 2 * Pow(16, j); break;
                case '3': decimalNumber += 3 * Pow(16, j); break;
                case '4': decimalNumber += 4 * Pow(16, j); break;
                case '5': decimalNumber += 5 * Pow(16, j); break;
                case '6': decimalNumber += 6 * Pow(16, j); break;
                case '7': decimalNumber += 7 * Pow(16, j); break;
                case '8': decimalNumber += 8 * Pow(16, j); break;
                case '9': decimalNumber += 9 * Pow(16, j); break;
                case 'A': decimalNumber += 10 * Pow(16, j); break;
                case 'B': decimalNumber += 11 * Pow(16, j); break;
                case 'C': decimalNumber += 12 * Pow(16, j); break;
                case 'D': decimalNumber += 13 * Pow(16, j); break;
                case 'E': decimalNumber += 14 * Pow(16, j); break;
                case 'F': decimalNumber += 15 * Pow(16, j); break;
                default: Console.WriteLine("Error!"); break;
            }
        }
        Console.WriteLine("Number in decimal = " + decimalNumber);
    }

    static int Pow(int x, int y)
    {
        int result = 1;
        for (int i = 0; i < y; i++)
        {
            result *= x;
        }
        return result;
    }

}

