using System;
//Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

class IsPrime
{
    static void Main()
    {
        Console.Write("Enter positive integer number:");
        int inputValue = int.Parse(Console.ReadLine());
        bool isPrime = true;
        if (inputValue == 0 || inputValue == 1)
        {
            Console.WriteLine("{0} is neither simple nor complex number.", inputValue);
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(inputValue); i++)
            {
                if (inputValue % i == 0)
                {
                    isPrime = false;
                }
            }
            Console.WriteLine("{0} is prime -> {1}", inputValue, isPrime);
        }
    }
}
