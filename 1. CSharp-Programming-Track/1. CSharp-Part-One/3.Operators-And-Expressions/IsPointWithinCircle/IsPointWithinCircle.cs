using System;
//Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

class IsPointWithinCircle
{
    static void Main()
    {
        Console.Write("Enter x coord:");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter y coord:");
        double y = double.Parse(Console.ReadLine());
        double r = 5;
        bool isPointWithinCircle = x * x + y * y <= r * r;
        Console.WriteLine("Point({0},{1}) is within circle(0,5) -> {2}", x, y, isPointWithinCircle);
    }
}

