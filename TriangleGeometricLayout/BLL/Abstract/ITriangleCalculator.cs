using TriangleGeometricLayout.Controllers;
using TriangleGeometricLayout.Domain;

namespace TriangleGeometricLayout.BLL.Abstract
{
    public interface ITriangleCalculator
    {
        Triangle CalculateTriangle(string row, int column);
        string GetRowColumn(Point p1, Point p2, Point p3);
    }
}