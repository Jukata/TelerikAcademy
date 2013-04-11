using System;
//In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
//Cn = (2n)! / (n+1)!*n! 
//Write a program to calculate the Nth Catalan number by given N.

class CatalanNumbers
{
    static void Main()
    {
        Console.Write("Enter n:");
        int n = int.Parse(Console.ReadLine());
        decimal result;
        decimal firstExpression = 1;
        decimal secondExpression = 1;
        for (int i = 2 * n, j = 2; i > n; i--, j++)
        {
            firstExpression *= i;
            secondExpression *= j;
        }
        result = firstExpression / secondExpression;
        Console.WriteLine(result);
    }
}

