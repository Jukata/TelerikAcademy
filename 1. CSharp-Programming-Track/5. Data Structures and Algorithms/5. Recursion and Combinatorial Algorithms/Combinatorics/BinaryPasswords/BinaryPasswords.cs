using System;
using System.Numerics;

class BinaryPasswords
{
    // http://bgcoder.com/Contest/Practice/59 - Task01

    private static BigInteger passwordsCount;

    static void Main()
    {
        char[] passwordPattern = Console.ReadLine().ToCharArray();
        //passwordsCount = 0;
        //GeneratePassword(passwordPattern, 0);

        passwordsCount = CalcPasswordsCount(passwordPattern);
        Console.WriteLine(passwordsCount);
    }

    private static BigInteger CalcPasswordsCount(char[] passwordPattern)
    {
        int unknownCount = 0;
        for (int i = 0; i < passwordPattern.Length; i++)
        {
            if (passwordPattern[i] == '*')
            {
                unknownCount++;
            }
        }

        BigInteger totalPasswordsCount = 1;
        for (int i = 0; i < unknownCount; i++)
        {
            totalPasswordsCount *= 2;
        }
        return totalPasswordsCount;
    }

    //slow solution ...
    //private static void GeneratePassword(char[] passwordPattern, int index)
    //{
    //    if (index == passwordPattern.Length)
    //    {
    //        passwordsCount++;
    //        return;
    //    }

    //    if (passwordPattern[index] != '*')
    //    {
    //        GeneratePassword(passwordPattern, index + 1);
    //        return;
    //    }


    //    passwordPattern[index] = '0';
    //    GeneratePassword(passwordPattern, index + 1);

    //    passwordPattern[index] = '1';
    //    GeneratePassword(passwordPattern, index + 1);

    //    passwordPattern[index] = '*';
    //}
}
