using System;

class FallDown
{
    static void Main()
    {
        int[] n = new int[8];
        for (int i = 0; i < 8; i++)
        {
            n[i] = int.Parse(Console.ReadLine());
        }

        int mask;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                mask = n[j];
                n[j] |= n[j - 1];
                n[j - 1] &= mask;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(n[i]);
        }
    }
}

