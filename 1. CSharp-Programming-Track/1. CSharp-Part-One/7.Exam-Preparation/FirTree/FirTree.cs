using System;

class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n * 2 - 3; j++)
            {
                if (i == n - 1)
                {
                    if (j < (n*2-3) / 2 || j > (n*2-3) / 2 )
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    if (j < (n*2-3) / 2 - i || j > (n*2-3) / 2 + i)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}