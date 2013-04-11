using System;
using System.Numerics;
//Write a program that reads a number N and calculates the sum of the first N members
//of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
//Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.



class SumOfFirstNFibonaciiMembers
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger firstMember = 0;
        BigInteger secondMember = 1;
        BigInteger fibonacciSum = 0;
        if (n > 1)
        {
            fibonacciSum = firstMember + secondMember;
            for (int i = 0; i < n - 2; i++)
            {
                secondMember = firstMember + secondMember;
                firstMember = secondMember - firstMember;
                fibonacciSum += secondMember;
            }
        }
        Console.WriteLine("Sum: {0}", fibonacciSum);
    }
}

