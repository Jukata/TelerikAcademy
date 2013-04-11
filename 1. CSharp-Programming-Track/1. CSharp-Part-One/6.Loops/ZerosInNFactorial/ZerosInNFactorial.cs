using System;
using System.Numerics;
//* Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//	N = 10  N! = 3628800  2
//	N = 20  N! = 2432902008176640000  4
//	Does your program work for N = 50 000?
//	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!

class ZerosInNFactorial
{
    static void Main()
    {

        Console.Write("Enter N:");
        int number = int.Parse(Console.ReadLine());
        int zeros = 0;
        for (int j = 1; j <= number / 5; j++)
        {
            zeros += (int)(number / Math.Pow(5.0, j));
        }
        //BigInteger nFact = 1;
        //for (int i = number; i > 0; i--)
        //{
        //    nFact *= i;
        //}
        //Console.Write(nFact);
        Console.WriteLine("Zeros = {0}", zeros);

    }
}

