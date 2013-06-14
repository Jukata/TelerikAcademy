//Write a program that finds all prime numbers in the range [1...10 000 000].
//Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

using System;

class SieveOfEratosthenes
{
    static void Main()
    {
        DateTime start = DateTime.Now;
        bool[] primeNumbers = new bool[10000001];
        int maxStep = (int)Math.Sqrt(primeNumbers.Length);

        for (int i = 0; i < primeNumbers.Length; i++) // All numbers are prime 
        {
            primeNumbers[i] = !primeNumbers[i];
        }


        for (int step = 2; step < maxStep; step++)
        {
            if (primeNumbers[step]) // if it's prime sieve...
            {
                for (int i = step+step; i < primeNumbers.Length; i += step)
                {
                    primeNumbers[i] = false;
                }
            }
        }

        //for (int i = 2; i < primeNumbers.Length; i++) // print prime numbers
        //{
        //    if (primeNumbers[i])
        //    {
        //        Console.WriteLine(i);
        //    }
        //}

        Console.WriteLine("Execution time = " + (DateTime.Now - start));
    }
}

