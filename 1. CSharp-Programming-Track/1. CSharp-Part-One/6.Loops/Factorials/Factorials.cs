using System;
//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

class Factorials
{
    static void Main()
    {
        Console.WriteLine("Enter N and K (1<N<K).");
        Console.Write("Enter N:");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K:");
        int k = int.Parse(Console.ReadLine());
        if (n > 1 && n < k)
        {
            decimal kFact = 1;
            decimal nFact = 1;
            //Console.WriteLine("Old logic:")
            //for (int i = k; i > (k - n); i--)
            //{
            //    kFact *= i;
            //}
            //for (int i = n; i > 0; i--)
            //{
            //    nFact *= i;
            //}
            //Console.WriteLine("N!*K! / (K-N)! = {0}", kFact * nFact);

            //Console.WriteLine("New logic:");
            //nFact = 1; kFact = 1;
            for (int i = n; i >= 1; i--)
            {
                nFact *= i;
                kFact *= k;
                k--;
            }
            decimal result = nFact * kFact;
            Console.WriteLine("N!*K! / (K-N)! = {0}", result);
        }
        else
        {
            Console.WriteLine("Wrong inerval.");
        }
    }
}

