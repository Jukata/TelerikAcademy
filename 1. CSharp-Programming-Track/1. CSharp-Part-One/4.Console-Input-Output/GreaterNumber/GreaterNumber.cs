using System;
//Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

class GreaterNumber
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Greater number={0}", Math.Max(firstNumber, secondNumber));
        Console.WriteLine("Smaller number={0}", Math.Min(firstNumber, secondNumber));
    }
}

