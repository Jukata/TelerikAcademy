using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    class Points
    {
        static void Main()
        {
            // testing points
            Point3D firstPoint = Point3D.CoordinateSystemCenter;
            Point3D seconPoint = new Point3D(1, 2, 1);
            Console.WriteLine("First point -> " + firstPoint);
            Console.WriteLine("Second point -> " + seconPoint);
            Console.WriteLine("Distance between the two points -> "
                + DistanceBetweenPoints.CaclculateDistance(firstPoint, seconPoint));
            Path myPath = new Path(5);
            myPath.AddPoint(firstPoint);
            myPath.AddPoint(firstPoint);
            myPath.AddPoint(new Point3D(3, 6, 1.5));
            myPath.AddPoint(firstPoint);
            myPath.AddPoint(seconPoint);
            myPath.AddPoint(firstPoint);
            myPath.AddPoint(seconPoint);
            myPath.RemovePoint(seconPoint);
            myPath.RemovePointAt(1);
            PathStorage.SaveToFile(myPath,null);
            Path otherPath = PathStorage.LoadFromFile("../../test.txt");
            otherPath.RemovePoint(firstPoint);
            PathStorage.SaveToFile(otherPath, "text.txt");
        }
    }
}
