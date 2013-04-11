using System;
//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

class Exchange3_4_5With24_25_26bits
{
    static void Main()
    {
        //Console.Write("Enter number:");
        uint number = 184549351u; // uint.Parse(Console.ReadLine());
        Console.WriteLine("{0,-5} {1}",number,Convert.ToString(number,2).PadLeft(31,'0'));
        uint mask = 7u;
        uint firstGroup = mask << 3 & number;
        uint secondGroup = mask << 24 & number;
        number = number & ~(mask << 3);
        number = number & ~(mask << 24);
        number = number | firstGroup << 21 | secondGroup >> 21;
        Console.WriteLine("{0,-5} {1}", number, Convert.ToString(number, 2).PadLeft(31, '0'));
    }
}

