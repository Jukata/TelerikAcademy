using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
    //Create a class Path to hold a sequence of points in the 3D space. 
    public class Path
    {
        private const int DefaultPathSize = 1024;
        private List<Point3D> pointsPath;

        public Path(int size = DefaultPathSize)
        {
            pointsPath = new List<Point3D>(size);
        }

        public int Count
        {
            get { return this.PointsPath.Count; }
        }

        public Point3D this[int index] // indexer
        {
            get
            {
                if (index < 0 || index >= pointsPath.Count)
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
                return pointsPath[index];
            }
            set
            {
                if (index < 0 || index >= pointsPath.Count)
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
                this.PointsPath[index] = value;
            }
        }

        public List<Point3D> PointsPath
        {
            get
            {
                return this.pointsPath;
            }
            private set
            {
                this.pointsPath = value;
            }
        }

        public void AddPoint(Point3D p) // add point to path
        {
            this.PointsPath.Add(p);
        }
        public void RemovePoint(Point3D p) // remove point from path
        {
            this.PointsPath.Remove(p);
        }
        public void RemovePointAt(int index) // remove point from path by index
        {
            this.PointsPath.RemoveAt(index);
        }
    }
}
