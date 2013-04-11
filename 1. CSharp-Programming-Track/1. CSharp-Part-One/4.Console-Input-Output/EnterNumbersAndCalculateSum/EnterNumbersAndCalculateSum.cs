using System;
//Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

class EnterNumbersAndCalculateSum
{
    static void Main()
    {
        Console.Write("Enter n=");
        uint numberOfNumbers = uint.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 0; i < numberOfNumbers; i++)
        {
            Console.Write("Enter next number:");
            double inputNumber = double.Parse(Console.ReadLine());
            sum += inputNumber;
        }
        Console.WriteLine("The sum of entered numbers is {0}", sum);
    }
}

