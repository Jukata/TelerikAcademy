//Write a method that returns the last digit of given integer as an 
//English word. Examples: 512 -> "two", 1024  "four", 12309 -> "nine".

using System;

class LastDigitInWords
{
    static void Main()
    {
        Console.Write("Enter number = ");
        int number = int.Parse(Console.ReadLine());
        string lastDigit = GetLastDigit(number);
        Console.WriteLine("The last digit of number {0} is {1}.", number, lastDigit);
    }

    static string GetLastDigit(int number)
    {
        if (number < 0)
        {
            number *= -1;
        }
        switch (number % 10)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default: return ("Not a number");
        }
    }
}

