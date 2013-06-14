//You are given a sequence of positive integer values written into a string, 
//separated by spaces. Write a function that reads these values
//from given string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461

using System;

class CalculateIntegerInOneLine
{
    static void Main()
    {
        Console.WriteLine("Enter integer in one line with spaces between them:");
        string inputNumbers = Console.ReadLine();
        int sum = CalculateSum(inputNumbers);
        inputNumbers = inputNumbers.Replace(" ", " + ");
        Console.WriteLine("The sum of integers {0} is = {1}", inputNumbers, sum);
    }

    static int CalculateSum(string inputNumbers)
    {
        int sum = 0;
        string[] numbers = inputNumbers.Split(' ');
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += int.Parse(numbers[i]);
        }
        return sum;
    }
}

