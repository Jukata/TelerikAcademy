using System;
//Sort 3 real values in descending order using nested if statements.

class SortThreeRealNumbers
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());
        double min = firstNumber;
        if (thirdNumber < secondNumber)
        {
            secondNumber = secondNumber + thirdNumber;
            thirdNumber = secondNumber - thirdNumber;
            secondNumber = secondNumber - thirdNumber;
        }
        if (secondNumber < firstNumber)
        {
            firstNumber = firstNumber + secondNumber;
            secondNumber = firstNumber - secondNumber;
            firstNumber = firstNumber - secondNumber;
        }
        if (thirdNumber < secondNumber)
        {
            thirdNumber = thirdNumber + secondNumber;
            secondNumber = thirdNumber - secondNumber;
            thirdNumber = thirdNumber - secondNumber;
        }
        Console.WriteLine("Sorting numbers...");
        Console.WriteLine("{0} {1} {2}", firstNumber, secondNumber, thirdNumber);
    }
}

