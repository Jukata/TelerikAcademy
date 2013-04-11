using System;
using System.Threading;
using System.Globalization;
using System.Text;
//Write a program that prints an isosceles triangle of 9 copyright symbols ©.
//Use Windows Character Map to find the Unicode code of the © symbol. Note: the © symbol may be displayed incorrectly.

class CopyrightTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        char copyrightSymbol = '\u00A9';
        Console.WriteLine("   " + copyrightSymbol);
        Console.WriteLine("  " + copyrightSymbol + " " + copyrightSymbol);
        Console.WriteLine(" " + copyrightSymbol + "   " + copyrightSymbol);
        Console.WriteLine(copyrightSymbol + " " + copyrightSymbol + " " + copyrightSymbol + " " + copyrightSymbol);
    }
}

