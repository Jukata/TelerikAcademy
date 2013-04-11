using System;
//Declare five variables choosing for each of them the most appropriate of the types 
//byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values:
//52130, -115, 4825932, 97, -10000.


class AppropriateTypes
{
    static void Main()
    {
        ushort firstVariable = 52130;
        sbyte secondVariable = -115;
        int thirdVariable = 4825932;
        byte forthVariable = 97;
        short fifthVariable = -10000;
        Console.WriteLine(firstVariable);
        Console.WriteLine(secondVariable);
        Console.WriteLine(thirdVariable);
        Console.WriteLine(forthVariable);
        Console.WriteLine(fifthVariable);
    }
}

