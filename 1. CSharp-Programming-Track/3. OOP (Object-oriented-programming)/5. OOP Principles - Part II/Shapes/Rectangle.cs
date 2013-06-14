using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    //Define new class Rectangle that implement the virtual method and return
    //the surface of the figure (height*width for rectangle). 
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            :base(width,height)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
