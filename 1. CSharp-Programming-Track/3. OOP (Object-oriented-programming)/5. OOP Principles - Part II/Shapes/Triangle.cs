using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    //Define new class Triangle that implement the virtual method and return
    //the surface of the figure (height*width/2 for triangle). 
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return this.width * this.height / 2;
        }
    }
}
