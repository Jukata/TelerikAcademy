using System;
using System.Numerics;
//Write a program to print the first 100 members of the sequence of 
//Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

class PrintFibonacci
{
    static void Main()
    {
        Console.WriteLine("First 100 members of the sequence of Fibonacci are:");
        BigInteger firstMember = 0;
        BigInteger secondMember = 1;
        Console.WriteLine(firstMember);
        Console.WriteLine(secondMember);
        for (int i = 0; i < 99; i++)
        {
            secondMember = firstMember + secondMember;
            firstMember = secondMember-firstMember;
            Console.WriteLine(secondMember);
        }
    }
}

