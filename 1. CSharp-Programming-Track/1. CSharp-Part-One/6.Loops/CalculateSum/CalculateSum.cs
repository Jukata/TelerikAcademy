using System;
//Write a program that, for a given two integer numbers N and X,
//calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N

class CalculateSum
{
    static void Main()
    {
        Console.WriteLine("Enter X and N for calculating the sum S = 1 + 1!/X + 2!/X^2 + … + N!/X^N");
        Console.Write("Enter X:");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Enter N:");
        int n = int.Parse(Console.ReadLine());
        decimal nFact;
        decimal xPower;
        decimal sum = 1;
        for (int i = 1; i <= n; i++)
        {
            nFact = 1;
            xPower = 1;
            for (int j = i; j >= 1; j--)
            {
                nFact *= j;
                xPower *= x;
            }
            sum += nFact / xPower;
        }
        Console.WriteLine("The sum is {0}", sum);
    }
}

