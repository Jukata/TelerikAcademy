using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    //Write a static class with a static method to calculate the distance between two points in the 3D space.

    static class DistanceBetweenPoints
    {
        public static double CaclculateDistance(Point3D p1, Point3D p2)
        {
            double distance = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y) + (p1.Z - p2.Z) * (p1.Z - p2.Z));
            return distance;
        }
    }
}
