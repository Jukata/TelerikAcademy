using System;

class IsPointInTriangle
{
    private static void Main(string[] args)
    {
        Point p = new Point(1, 1);
        Point p1 = new Point(0, 0);
        Point p2 = new Point(0, 5);
        Point p3 = new Point(2.5, 1);

        if (Point.IsPointInsideTriangle(p, p1, p2, p3))
        {
            Console.WriteLine("Point is in triangle.");
        }
        else
        {
            Console.WriteLine("Point isn't in triangle");
        }
    }
}