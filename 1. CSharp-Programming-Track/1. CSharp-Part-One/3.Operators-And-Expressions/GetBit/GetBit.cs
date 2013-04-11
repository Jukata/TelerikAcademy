using System;
//Write an expression that extracts from a given integer i 
//the value of a given bit number b. Example: i=5; b=2  value=1.

class GetBit
{
    static void Main()
    {
        Console.Write("integer i=");
        uint i = uint.Parse(Console.ReadLine());
        Console.Write("Position b=");
        byte b = byte.Parse(Console.ReadLine());
        bool bit = (((1 << b) & i) >> b) == 1;
        if (bit)
        {
            Console.WriteLine("Value of bit {0} in number {1} is 1",b,i);
        }
        else
        {
            Console.WriteLine("Value of bit {0} in number {1} is 0", b, i);
        }
    }
}

