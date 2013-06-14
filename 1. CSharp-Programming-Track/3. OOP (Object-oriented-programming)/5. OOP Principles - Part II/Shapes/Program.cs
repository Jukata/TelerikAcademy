using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        //Write a program that tests the behavior of  the CalculateSurface() method for 
        //different shapes (Circle, Rectangle, Triangle) stored in an array.

        static void Main()
        {
            Shape[] shapes = 
            {
                new Circle(10),
                new Rectangle(2,2),
                new Rectangle(3,3),
                new Triangle(3,2),
                new Circle(5),
                new Rectangle(5,1),
                new Rectangle(3,5),
                new Triangle(6,2),
            };
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("I am {0}. My surface = {1}.", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
