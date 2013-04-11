using System;
//Write a program that reads 3 integer numbers from the console and prints their sum.

class ReadThreeIntegers
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());
        long sum = firstNumber + secondNumber + thirdNumber;
        Console.WriteLine("{0}+{1}+{2}={3}", firstNumber, secondNumber, thirdNumber, sum);
    }
}

