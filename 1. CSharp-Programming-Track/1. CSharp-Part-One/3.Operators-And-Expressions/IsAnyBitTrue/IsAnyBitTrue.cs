using System;
//Write a boolean expression that returns if the bit at position p (counting from 0) 
//in a given integer number v has value of 1. Example: v=5; p=1  false.

class IsAnyBitTrue
{
    static void Main()
    {
        Console.Write("Enter position p=");
        byte p = byte.Parse(Console.ReadLine());
        Console.Write("Enter number v=");
        uint v = uint.Parse(Console.ReadLine());
        bool isBitTrue = (((1 << p) & v) >> p) == 1;
        if (isBitTrue)
        {
            Console.WriteLine("Bit on position {0} in number {1} is 1");
        }
        else
        {
            Console.WriteLine("Bit on position {0} in number {1} is 0");
        }

    }
}

