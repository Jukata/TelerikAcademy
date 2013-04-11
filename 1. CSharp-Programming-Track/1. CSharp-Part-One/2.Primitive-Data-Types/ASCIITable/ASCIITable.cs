using System;

class ASCIITable
{
    static void Main()
    {
        Console.WriteLine("Dec  |Hex  |Char ");
        for (int i = 0; i < 256; i++)
        {
            Console.WriteLine("{0,-5}|{1,-5:X}|{2,-5}", i,i,(char)i);
        }
    }
}

