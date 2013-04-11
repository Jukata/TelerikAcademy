using System;
//Write a program that reads the radius r of a circle and prints its perimeter and area.

class CalculateCircleRadiusAndPerimeter
{
    static void Main()
    {
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine("Circle area={0}",Math.PI*r*r);
        Console.WriteLine("Circle perimeter={0}",Math.PI*2*r);
    }
}

