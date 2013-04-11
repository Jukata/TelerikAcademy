using System;
//Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

class IsDivisibleBy5and7
{
    static void Main()
    {
        int inputValue = int.Parse(Console.ReadLine());
        bool isInputDivisibleBy5and7 = inputValue % 5 == 0 && inputValue % 7 == 0;
        Console.WriteLine("Is {0} divisible to 5 and 7 - {1}.", inputValue, isInputDivisibleBy5and7);
    }
}

