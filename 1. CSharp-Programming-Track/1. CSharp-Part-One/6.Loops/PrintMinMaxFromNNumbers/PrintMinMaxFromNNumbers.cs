using System;
//Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

class PrintMinMaxFromNNumbers
{
    static void Main()
    {
        Console.Write("Enter n:");
        uint n = uint.Parse(Console.ReadLine());
        uint min = uint.MaxValue;
        uint max = uint.MinValue;
        for (int i = 1; i <= n; i++)
        {
            Console.Write("Enter {0} number=", i);
            uint inputNumber = uint.Parse(Console.ReadLine());
            if (inputNumber < min)
            {
                min = inputNumber;
            }
            if (inputNumber > max)
            {
                max = inputNumber;
            }
        }
        Console.WriteLine("Min={0}", min);
        Console.WriteLine("Max={0}", max);
    }

}
