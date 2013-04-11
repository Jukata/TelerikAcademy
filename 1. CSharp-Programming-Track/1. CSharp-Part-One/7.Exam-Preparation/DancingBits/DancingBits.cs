using System;
using System.Numerics;

class DancingBits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int dancingBitsCount = 0;
        string bigNumberInBinary = "";
        for (int i = 0; i < n; i++)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            bigNumberInBinary += Convert.ToString(inputNumber, 2);
        }

        char checker = bigNumberInBinary[0];
        int count = 1;
        for (int i = 1; i < bigNumberInBinary.Length; i++)
        {
            if (checker == bigNumberInBinary[i])
            {
                count++;
            }
            else
            {
                if (count == k)
                {
                    dancingBitsCount++;
                }
                count = 1;
                checker = bigNumberInBinary[i];
            }
        }
        if (count == k)
        {
            dancingBitsCount++;
        }
        Console.WriteLine(dancingBitsCount);

    }
}

