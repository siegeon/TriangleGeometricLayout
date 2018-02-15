namespace TriangleGeometricLayout.Controllers
{
    public class Triangle
    {
        public readonly Point[] points = new Point[3];

        public Triangle(Point p1, Point p2, Point p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }
    }
}