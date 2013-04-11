using System;
//Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

class IsThirdDigitSeven
{
    static void Main()
    {
        int inputValue = int.Parse(Console.ReadLine());
        if (inputValue < 0)
        {
            inputValue *= -1; // Make integer positive
        }
        bool isThirdDigit7 = ((inputValue % 1000) / 100) == 7;
        Console.WriteLine("Third digit of {0} is 7 -> {1}", inputValue, isThirdDigit7);
    }
}

