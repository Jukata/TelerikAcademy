using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    //Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.

    public abstract class Shape
    {
        protected double width;
        protected double height;

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be positive.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be positive.");
                }
                this.height = value;
            }
        }

        protected Shape(double width,double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract double CalculateSurface();
    }
}
