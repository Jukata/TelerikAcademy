using System;

class AstrologicalDigits
{
    static void Main()
    {
        string n = Console.ReadLine();
        do
        {
            int sum = 0;
            foreach (char ch in n)
            {
                if (ch >= '0' && ch <= '9')
                {
                    sum += ch - '0';
                }
            }
            n = sum.ToString();
        }
        while (int.Parse(n) > 9);
        Console.WriteLine(n);
    }
}

