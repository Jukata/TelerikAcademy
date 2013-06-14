//Write a program to calculate n! for each n in the range [1..100]. Hint: 
//Implement first a method that multiplies a number represented as array of digits by given integer number. 

using System;

class NFactWithMultiplicationOfNumbersAsArrays 
{
    static void Main()
    {
        // Really slow algorithm... but the condition requires this way :/
        // Reusing Task8 Sum Numbers As Arrays

        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        int[] result = {1};
        for (int i = 2; i <= n; i++)
        {
            result = Multiply(result,i);
        }
        Console.Write("n! = ");
        Print(result);
        Console.WriteLine();
    }

    private static void Print(int[] result)
    {
        bool hasTrailingZeros = true;
        foreach (int digit in result)
        {
            if (hasTrailingZeros && digit == 0)
            {
                continue;
            }
            hasTrailingZeros = false;
            Console.Write(digit);
        }
    }

    static int[] Multiply(int[] array, int n)
    {
        if (n >= 2)
        {
            int[] result = Sum(array, array);

            for (int i = 2; i < n; i++)
            {
                result = Sum(result, array);
            }
            return result;
        }
        else
        {
            return array;
        }
    }   
    
    

    static int[] Sum(int[] firstNumberDigits, int[] secondNumberDigits)
    {
        string firstNumber ="";
        string secondNumber ="";
        for (int i = 0; i < firstNumberDigits.Length; i++)
        {
            firstNumber += firstNumberDigits[i];
        } 
        for (int i = 0; i < secondNumberDigits.Length; i++)
        {
            secondNumber += secondNumberDigits[i];
        }
        int maxLength = Max(firstNumber.Length, secondNumber.Length);
        firstNumberDigits = new int[maxLength];
        secondNumberDigits = new int[maxLength];
        for (int i = firstNumber.Length - 1, j = maxLength - 1; i >= 0; i--, j--)
        {
            firstNumberDigits[j] = int.Parse(firstNumber[i].ToString());
        }
        for (int i = secondNumber.Length - 1, j = maxLength - 1; i >= 0; i--, j--)
        {
            secondNumberDigits[j] = int.Parse(secondNumber[i].ToString());
        }
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

