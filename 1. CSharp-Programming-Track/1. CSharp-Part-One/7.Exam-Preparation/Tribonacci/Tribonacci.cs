using System;
using System.Numerics;

class Tribonacci
{
    static void Main(string[] args)
    {
        BigInteger T1 = BigInteger.Parse(Console.ReadLine());
        BigInteger T2 = BigInteger.Parse(Console.ReadLine());
        BigInteger T3 = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        if (n == 1)
        {
            Console.WriteLine(T1);
        }
        else if (n == 2)
        {
            Console.WriteLine(T2);
        }
        else if (n == 3)
        {
            Console.WriteLine(T3);
        }
        else
        {
            BigInteger Tn = 0;
            for (int i = 0; i < n-3; i++)
            {
                Tn = T1 + T2 + T3;
                T1 = T2;
                T2 = T3;
                T3 = Tn;
            }
            Console.WriteLine(Tn);
        }
    }
}
