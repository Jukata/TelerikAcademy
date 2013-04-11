using System;
//Write a program that safely compares floating-point numbers with precision of 0.000001.
//Examples:(5.3 ; 6.01) -> false;  (5.00000001 ; 5.00000003) -> true


class SafetyCompareFloatNumbers
{
    static void Main()
    {
        double firstFloatingNumber = 5.3;
        double secondFloatingNumber = 6.01;
        Compare(firstFloatingNumber, secondFloatingNumber);
        double thirdFloatingNumber = 5.00000001;
        double forthFloatingNumber = 5.00000003;
        Compare(thirdFloatingNumber, forthFloatingNumber);
    }

    static void Compare(double a, double b)
    {
        if (Math.Abs(a - b) < 0.000001)
        {
            Console.WriteLine("{0} and {1} are equals", a, b);
        }
        else
        {
            Console.WriteLine("{0} and {1} are not equals", a, b);
        }
    }
}

