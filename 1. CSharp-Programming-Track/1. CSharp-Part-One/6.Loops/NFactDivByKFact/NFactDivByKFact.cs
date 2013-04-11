using System;
//Write a program that calculates N!/K! for given N and K (1<K<N).

class NFactDivByKFact
{
    static void Main()
    {
        Console.WriteLine("Enter values for N and K (1<K<N)");
        Console.Write("Enter N:");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K:");
        int k = int.Parse(Console.ReadLine());
        //decimal nFaktoriel = 1;
        //decimal kFaktoriel = 1;
        //for (int i = n; i > 0; i--)
        //{
        //    nFaktoriel *= i;
        //}
        //for (int i = k; i > 0; i--)
        //{
        //    kFaktoriel *= i;
        //}
        //Console.WriteLine("N!={0}",nFaktoriel);
        //Console.WriteLine("K!={0}",kFaktoriel);
        //Console.WriteLine("N!/K!={0}",nFaktoriel/kFaktoriel);
        decimal result=1;
        if (n > k && k > 0)
        {
            for (int i = n; i > k; i--)
            {
                result *= i;
            }
            Console.WriteLine("N!/K! = {0}", result);
        }
        else
        {
            Console.WriteLine("Wrong intervals!");
        }
    }
}

