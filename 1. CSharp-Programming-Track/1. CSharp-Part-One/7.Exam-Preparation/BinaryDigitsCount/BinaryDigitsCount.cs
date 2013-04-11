using System;

class BinaryDigitsCount
{
    static void Main()
    {
        int b = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int bitsCount = 0;
        for (int i = 0; i < n; i++)
        {
            bitsCount = 0;
            uint inputNum = uint.Parse(Console.ReadLine());
            while (inputNum > 0)
            {
                if ((inputNum & 1) == b)
                {
                    bitsCount++;
                }
                inputNum >>= 1;
            }
            Console.WriteLine(bitsCount);
        }
    }
}

