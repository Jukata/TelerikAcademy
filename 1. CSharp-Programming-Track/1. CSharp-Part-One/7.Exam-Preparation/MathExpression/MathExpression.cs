using System;

class MathExpression
{
    static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        double m = double.Parse(Console.ReadLine());
        double p = double.Parse(Console.ReadLine());
        double nominator = n * n + 1 / (m * p) + 1337;
        double denominator = n - 128.523123123 * p;
        double result = nominator / denominator + Math.Sin((int)(m % 180));
        Console.WriteLine("{0:F6}",result);
    }
}

