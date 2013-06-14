//Write a method GetMax() with two parameters that returns the bigger of two integers.
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().


using System;

class GetMaxInteger
{
    static void Main()
    {
        Console.Write("Enter x = ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Enter y = ");
        int y = int.Parse(Console.ReadLine());
        Console.Write("Enter z = ");
        int z = int.Parse(Console.ReadLine());
        int max = GetMax(GetMax(x, y), z);
        Console.WriteLine("The max number is = {0}", max);
    }

    static int GetMax(int x, int y)
    {
        if (x > y)
        {
            return x;
        }
        else
        {
            return y;
        }
    }
}

