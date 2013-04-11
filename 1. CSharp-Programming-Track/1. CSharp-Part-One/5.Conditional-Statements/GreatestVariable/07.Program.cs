using System;
//Write a program that finds the greatest of given 5 variables.

class GreatestVariable
{
    static void Main()
    {
        Console.Write("Enter variable:");
        double firstVarible = double.Parse(Console.ReadLine());
        Console.Write("Enter variable:");
        double secondVariable = double.Parse(Console.ReadLine());
        Console.Write("Enter variable:");
        double thirdVariable = double.Parse(Console.ReadLine());
        Console.Write("Enter variable:");
        double forthVariable = double.Parse(Console.ReadLine());
        Console.Write("Enter variable:");
        double fifthVariable = double.Parse(Console.ReadLine());
        double greatest = double.MinValue;
        if (firstVarible > greatest)
        {
            greatest = firstVarible;
        }
        if (secondVariable > greatest)
        {
            greatest = secondVariable;
        }
        if (thirdVariable > greatest)
        {
            greatest = thirdVariable;
        }
        if (forthVariable > greatest)
        {
            greatest = forthVariable;
        }
        if (fifthVariable > greatest)
        {
            greatest = fifthVariable;
        }
        Console.WriteLine("Greatest = {0}", greatest);
    }
}

