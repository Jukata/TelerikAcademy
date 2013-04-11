using System;
//Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).


class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter coefficients a, b and c for equation ax^2 + bx + c = 0.");
        Console.Write("Enter a=");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b=");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c=");
        double c = double.Parse(Console.ReadLine());
        if (a != 0)
        {
            double d = b * b - 4 * a * c;
            if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("x1={0}", x1);
                Console.WriteLine("x2={0}", x2);
            }
            else if (d == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("x1=x2={0}", x);
            }
            else if (d < 0)
            {
                Console.WriteLine("The equation has no real roots");
            }
        }
        else
        {
            if (b != 0)
            {
                double x = -c / b;
                Console.WriteLine("x={0}", x);
            }
            else
            {
                Console.WriteLine("The equation has no solution");
            }
        }
    }
}

