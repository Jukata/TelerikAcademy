using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n/2+1; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (j < i || j>n-i+1)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }
        for (int i = n/2; i >= 1; i--)
        {
            for (int j = 1; j <= n; j++)
            {
                if (j < i || j > n - i + 1)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }












        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        for (int i = 0; i < n/2+1; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j < i || j > n -1- i)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }
        for (int i = n/2; i > 0; i--)
        {
            for (int j = 1; j <=n; j++)
            {
                if (j < i || j > n + 1 - i)
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }
    }
}

