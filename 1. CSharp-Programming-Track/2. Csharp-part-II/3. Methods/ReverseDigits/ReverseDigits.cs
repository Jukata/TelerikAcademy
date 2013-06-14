//Write a method that reverses the digits of given decimal number. Example: 256 -> 652

using System;

class ReverseDigits
{
    static void Main()
    {
        //user input
        Console.Write("Enter number for reverse = ");
        decimal number = decimal.Parse(Console.ReadLine());
        decimal reversedNumber = ReverseNumber(number);
        Console.WriteLine(number + " -> " + reversedNumber);
    }

    static decimal ReverseNumber(decimal number)
    {
        bool negative = false;
        if (number < 0)
        {
            number *= -1;
            negative = true;
        }
        char[] reversedNumber = number.ToString().ToCharArray();
        Array.Reverse(reversedNumber);
        number = decimal.Parse(new string(reversedNumber));

        if (negative)
        {
            number *= -1;
        }

        return number;

        //int reversedNumber = 0;
        //while (number > 0)
        //{
        //    reversedNumber *= 10;
        //    reversedNumber += (number % 10);
        //    number /= 10;
        //};
        //return reversedNumber;

    }
}

