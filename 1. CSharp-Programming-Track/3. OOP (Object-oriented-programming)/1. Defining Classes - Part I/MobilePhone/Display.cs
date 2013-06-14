//display characteristics (size and number of colors). 

using System;

namespace MobilePhone
{
    public class Display
    {
        //fields
        private float? size;
        private int? colors;

        //properties
        public float? Size
        {
            get { return this.size; }
            set 
            {
                if (value <= 0) // display diagonal in inches can't be 0 or negative
                {
                    throw new ArgumentOutOfRangeException("Display size must be > 0");
                }
                this.size = value;
            }
        }
        public int? Colors
        {
            get { return this.colors; }
            set 
            {
                if (value < 2) // at least black and white.
                {
                    throw new ArgumentOutOfRangeException("Colors must be at least 2");
                }
                this.colors = value;
            }
        }

        //constructors
        public Display():this(null,null)
        {
        }
        public Display(float? size, int? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
    }
}
