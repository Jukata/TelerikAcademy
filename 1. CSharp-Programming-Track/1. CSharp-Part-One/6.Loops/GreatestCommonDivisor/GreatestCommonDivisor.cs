using System;
//Write a program that calculates the greatest common divisor (GCD)
//of given two numbers. Use the Euclidean algorithm (find it in Internet).

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        int remainder;
        if (secondNumber > firstNumber)
        {
            firstNumber = firstNumber + secondNumber;
            secondNumber = firstNumber - secondNumber;
            firstNumber = firstNumber - secondNumber;
        }
        if (firstNumber != 0 && secondNumber != 0) // avoid divide by zero
        {
            do
            {
                remainder = firstNumber % secondNumber;
                firstNumber = secondNumber;
                secondNumber = remainder;
            } while (remainder != 0);
            Console.WriteLine("Greatest common divisor = {0}", firstNumber);
        }
        else
        {
            Console.WriteLine("Greatest common divisor = {0}", firstNumber);
        }
    }
}


