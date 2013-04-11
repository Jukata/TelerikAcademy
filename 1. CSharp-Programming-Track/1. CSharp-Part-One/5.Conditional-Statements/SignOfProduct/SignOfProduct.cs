using System;
//Write a program that shows the sign (+ or -) of the product of three real numbers
//without calculating it. Use a sequence of if statements.


class SignOfProduct
{
    static void Main()
    {
        int a = -1;
        int b = -2;
        int c = 3;
        if (a == 0 || b==0 || c==0)
        {
            Console.WriteLine("Product is 0");
        }
        else if (a > 0)
        {
            if (b > 0)
            {
                if (c > 0)
                {
                    Console.WriteLine("Product is positive");
                }
                else
                {
                    Console.WriteLine("Product is negative");
                }
            }
            else // a>0 b<0
            {
                if (c > 0)
                {
                    Console.WriteLine("Product is negative");
                }
                else
                {
                    Console.WriteLine("Product is positive");
                }
            }
        }
        else // a < 0
        {
            if (b > 0)
            {
                if (c > 0)
                {
                    Console.WriteLine("Product is negative");
                }
                else
                {
                    Console.WriteLine("Product is positive");
                }
            }
            else // b<0
            {
                if (c > 0)
                {
                    Console.WriteLine("Product is positive");
                }
                else
                {
                    Console.WriteLine("Product is negative");
                }
            }
        }
    }
}

