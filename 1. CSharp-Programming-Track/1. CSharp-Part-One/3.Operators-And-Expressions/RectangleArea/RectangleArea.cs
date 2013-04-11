using System;
//Write an expression that calculates rectangle’s area by given width and height.

class RectangleArea
{
    static void Main()
    {
        uint width = uint.Parse(Console.ReadLine());
        uint height = uint.Parse(Console.ReadLine());
        ulong area = width * height;
        Console.WriteLine("The area of rectangle with height {0} and width {1} is {2}.", height, width, area);
    }
}

