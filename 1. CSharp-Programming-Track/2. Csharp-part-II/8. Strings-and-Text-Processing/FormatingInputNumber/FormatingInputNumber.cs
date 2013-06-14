//Write a program that reads a number and prints it as a 
//decimal number, hexadecimal number, percentage and in scientific notation. 
//Format the output aligned right in 15 symbols.

using System;

class FormatingInputNumber
{
    static void Main()
    {
        Console.Write("Enter number = ");
        int inputNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("{0,15:D}", inputNumber);
        Console.WriteLine("{0,15:X}", inputNumber);
        Console.WriteLine("{0,15:P}", inputNumber);
        Console.WriteLine("{0,15:E}", inputNumber);
    }
}

