using System;
//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.



class FindThirdBit
{
    static void Main()
    {
        uint inputValue = uint.Parse(Console.ReadLine());
        uint mask = 1 << 3;
        uint thirdBit = (inputValue & mask)>>3;
        Console.WriteLine("Third bit of number {0} is {1}", inputValue, thirdBit);
    }
}

