using System;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < 2 * n; i++)
        {
            if (i < n)
            {
                Console.Write(".");
            }
            else
            {
                Console.Write("*");
            }
        }
        Console.WriteLine();

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < 2*n; j++)
            {
                if (n - i - 1 == j || j == 2 * n - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }

        for (int i = 0; i < 2 * n; i++)
        {
            Console.Write("*");
        }
    }
}

