//Write a program to convert from any numeral system of given
//base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;

class FromAnyToAnyBase
{
    static void Main()
    {
        Console.Write("Enter from what base do you want to convert: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Enter to what base do you want to convert: ");
        int d = int.Parse(Console.ReadLine());
        Console.Write("Enter number = ");
        String baseS = Console.ReadLine();
        Console.WriteLine("Number in {0} numeral system = {1}", s, baseS);
        int decimalNumber = 0;
        baseS.ToUpper();
        for (int i = baseS.Length - 1, j = 0; i >= 0; i--, j++)
        {
            if (char.IsDigit(baseS[i]))
            {
                decimalNumber += int.Parse(baseS[i].ToString()) * Pow(s, j);
            }
            else // letter
            {
                decimalNumber += (baseS[i] - 'A' + 10) * Pow(s, j);
            }
        }
        Console.WriteLine("Number in decimal = " + decimalNumber);
        string remainders = "";
        do
        {
            int remainder = decimalNumber % d;
            if ( remainder < 10)
            {
                remainders += decimalNumber % d;
            }
            else //letter
            {
                remainders +=(char)('A' - 10 + decimalNumber % d);
            }
            decimalNumber /= d;
        } while (decimalNumber > 0);
        string baseD = "";
        for (int i = 0; i < remainders.Length; i++)
        {
            baseD = remainders[i] + baseD;
        }
        Console.WriteLine("Number in {0} numeral system = {1}", d, baseD);
    }

    static int Pow(int x, int y)
    {
        int result = 1;
        for (int i = 0; i < y; i++)
        {
            result *= x;
        }
        return result;
    }
}

