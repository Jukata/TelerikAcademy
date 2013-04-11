using System;
//Write a program that finds the biggest of three integers using nested if statements.

class BiggestInteger
{
    static void Main()
    {
        int firstInt = 10;
        int secondInt = 14;
        int thirdInt = 14;
        int biggestInt = firstInt;
        if (secondInt > biggestInt)
        {
            biggestInt = secondInt;
        }
        if (thirdInt > biggestInt)
        {
            biggestInt = thirdInt;
        }
        Console.WriteLine("Biggest int = {0}", biggestInt);
    }
}

