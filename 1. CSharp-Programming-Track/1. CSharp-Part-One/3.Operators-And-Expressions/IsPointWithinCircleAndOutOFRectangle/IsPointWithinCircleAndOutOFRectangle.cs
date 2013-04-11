using System;
//Write an expression that checks for given point (x, y) if it is within
//the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

class IsPointWithinCircleAndOutOFRectangle
{
    static void Main()
    {
        Console.Write("x coord=");
        double x = double.Parse(Console.ReadLine());
        Console.Write("y coord=");
        double y = double.Parse(Console.ReadLine());
        bool isOutOfRectangle = x < -1 || x > 5 || y > 1 || y < -1;
        bool isWithinCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= 9;
        if (isOutOfRectangle && isWithinCircle)
        {
            Console.WriteLine("Point IS within the circle AND out of rectangle.");
        }
        else
        {
            Console.WriteLine("The point IS NOT within the circle AND out of rectangle.");
        }
    }
}

