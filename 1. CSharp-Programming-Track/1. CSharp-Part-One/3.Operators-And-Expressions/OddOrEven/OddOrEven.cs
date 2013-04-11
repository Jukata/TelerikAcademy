using System;
//Write an expression that checks if given integer is odd or even.

class OddOrEven
{
    static void Main()
    {
        int inputValue = int.Parse(Console.ReadLine());
        Console.WriteLine("{0} is {1}.", inputValue, inputValue%2==0 ? "even":"odd" );
    }
}

