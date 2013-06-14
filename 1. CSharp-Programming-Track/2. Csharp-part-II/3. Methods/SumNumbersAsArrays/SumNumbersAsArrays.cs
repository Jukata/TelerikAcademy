//Write a method that adds two positive integer numbers represented as arrays of digits
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.

using System;

class SumNumbersAsArrays
{
    static void Main()
    {
        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();
        int maxLength = Max(firstNumber.Length, secondNumber.Length);
        int[] firstNumberDigits = new int[maxLength];
        int[] secondNumberDigits = new int[maxLength];
        for (int i = firstNumber.Length - 1, j = maxLength - 1; i >= 0; i--, j--)
        {
            firstNumberDigits[j] = int.Parse(firstNumber[i].ToString());
        }
        for (int i = secondNumber.Length - 1, j = maxLength - 1; i >= 0; i--, j--)
        {
            secondNumberDigits[j] = int.Parse(secondNumber[i].ToString());
        }
        int[] result = Sum(firstNumberDigits, secondNumberDigits);

        Console.WriteLine();
        Console.Write(" ");
        foreach (int digit in firstNumberDigits)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
        Console.WriteLine("+");
        Console.Write(" ");
        foreach (int digit in secondNumberDigits)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
        Console.WriteLine(new string('-',maxLength+1));
        foreach (int digit in result)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
        //for (int i = maxLength - 1; i >= maxLength - firstNumber.Length; i--)
        //{
        //    firstNumberDigits[i] = firstNumber[i];
        //} 
        //for (int i = maxLength - 1; i >= maxLength - secondNumber.Length; i--)
        //{

        //}
        //secondNumberDigits = secondNumber.ToCharArray();
        //Array.Reverse(secondNumberDigits);
        //Sum(firstNumberDigits, secondNumberDigits);
    }

    static int[] Sum(int[] firstNumberDigits, int[] secondNumberDigits)
    {
        int[] result = new int[firstNumberDigits.Length + 1];
        int carry = 0;
        for (int i = firstNumberDigits.Length - 1, j = result.Length - 1; i >= 0; i--, j--)
        {
            if (firstNumberDigits[i] + secondNumberDigits[i] + carry >= 10)
            {
                result[j] = firstNumberDigits[i] + secondNumberDigits[i] - 10 + carry;
                carry = 1;
            }
            else
            {
                result[j] = firstNumberDigits[i] + secondNumberDigits[i] + carry;
                carry = 0;
            }
        }
        if (carry == 1)
        {
            result[0] = 1;
        }
        return result;
    }

    static int Max(int x, int y)
    {
        if (x > y)
        {
            return x;
        }
        else
        {
            return y;
        }
    }
}
