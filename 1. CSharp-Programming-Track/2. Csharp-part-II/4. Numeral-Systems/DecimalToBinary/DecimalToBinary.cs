//Write a program to convert decimal numbers to their binary representation.

using System;

class DecimalToBinary
{
    static void Main()
    {

        Console.Write("Enter n = ");
        int decNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Number in decimal = " + decNumber);
        string remainders = "";
        do
        {
            remainders += decNumber % 2;
            decNumber /= 2;
        } while (decNumber > 0);
        string binNumber = "";
        for (int i = remainders.Length - 1; i >= 0; i--)
        {
            binNumber += remainders[i];
        }
        Console.WriteLine("Number in binary = " + binNumber);

    }
}

