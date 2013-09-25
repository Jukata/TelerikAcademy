public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public static bool IsPointInsideTriangle(Point p, Point p1, Point p2, Point p3)
    {

        double lambda1 = ((p2.Y - p3.Y) * (p.X - p3.X) + (p3.X - p2.X) * (p.Y - p3.Y)) /
                ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));

        double lambda2 = ((p3.Y - p1.Y) * (p.X - p3.X) + (p1.X - p3.X) * (p.Y - p3.Y)) /
               ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));

        double lambda3 = 1 - lambda1 - lambda2;

        bool isInTriangle =
            (0 <= lambda1 && lambda1 <= 1) &&
            (0 <= lambda2 && lambda2 <= 1) &&
            (0 <= lambda3 && lambda3 <= 1);

        return isInTriangle;
    }
}