//Write a program to convert binary numbers to their decimal representation.
using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Enter number in binary = ");
        string binaryNumber = Console.ReadLine();
        int decimalNumber = 0;

        for (int i = binaryNumber.Length - 1, j = 0; i >= 0; i--, j++)
        {
            decimalNumber += int.Parse(binaryNumber[i].ToString()) * (1 << j);
        }

        Console.WriteLine("Number in binary = " + binaryNumber);
        Console.WriteLine("Number in decimal = " + decimalNumber);
    }
}

