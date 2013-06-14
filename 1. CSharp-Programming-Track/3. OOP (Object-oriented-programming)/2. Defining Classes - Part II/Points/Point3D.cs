using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    //Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
    //Implement the ToString() to enable printing a 3D point.
    public struct Point3D
    {
        private double x;
        private double y;
        private double z;
        
        //Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
        //Add a static property to return the point O.
        private static readonly Point3D coordinateSystemCenter = new Point3D(0,0,0);

        public static Point3D CoordinateSystemCenter
        {
            get
            {
                return coordinateSystemCenter;
            }
        }

        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public double Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("(x={0}, y={1}, z={2})", this.X, this.Y, this.Z);
        }
    }
}
