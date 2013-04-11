using System;
//* Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

class ExchangeBits
{
    static void Main()
    {
        Console.Write("Enter p:");
        byte p = byte.Parse(Console.ReadLine());
        Console.Write("Enter q:");
        byte q = byte.Parse(Console.ReadLine());
        Console.Write("Enter k:");
        byte k = byte.Parse(Console.ReadLine());
        Console.Write("Enter number:");
        uint number = uint.Parse(Console.ReadLine());
        Console.WriteLine("{0,-5} {1}", number, Convert.ToString(number, 2).PadLeft(31, '0'));
        for (int i = 0; i < k; i++)
        {
            uint firstBit = ((1u << (p + i)) & number)>>(p+i);
            uint secondBit = ((1u << (q + i)) & number)>>(q+i);
            number = number & ~(1u << (p + i));
            number = number & ~(1u << (q + i));
            number = number | firstBit<<(q+i) | secondBit<<(p+i);
        }
        Console.WriteLine("{0,-5} {1}", number, Convert.ToString(number, 2).PadLeft(31, '0'));

    }
}