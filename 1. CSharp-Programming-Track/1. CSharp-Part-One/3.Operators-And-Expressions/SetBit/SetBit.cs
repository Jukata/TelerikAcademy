using System;
//We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that
//modifies n to hold the value v at the position p from the binary representation of n.
//	Example: n = 5 (00000101), p=3, v=1  13 (00001101)
//	n = 5 (00000101), p=2, v=0  1 (00000001)

class SetBit
{
    static void Main()
    {
        Console.Write("Enter number n=");
        uint n = uint.Parse(Console.ReadLine());
        Console.Write("Enter value 0 or 1 v=");
        byte v = byte.Parse(Console.ReadLine());
        Console.Write("Enter position p=");
        byte p = byte.Parse(Console.ReadLine());
        Console.WriteLine(n+"  "+Convert.ToString(n,2).PadLeft(31,'0'));
        if (v == 0)
        {
            n = ~(1u << p) & n ;
            Console.WriteLine(n+"  "+Convert.ToString(n,2).PadLeft(31,'0'));
        }
        else if (v == 1)
        {
            n = (1u << p) | n;
            Console.WriteLine(n + "  " + Convert.ToString(n, 2).PadLeft(31, '0'));
        }
        else
        {
            Console.WriteLine("Invalid value for v.");
        }
    }
}

