using System;
using TriangleGeometricLayout.Controllers;

namespace TriangleGeometricLayout.BLL
{
    public static class TriangleCalculator
    {
        public static Triangle CalculateTriangle(string row, int column)
        {
            var x = (int)Math.Ceiling((double)column / 2)-1;
            var y = RowMapper.GetValue(row);


            return column % 2 == 0 ?
                EvenTriangle(x, y) : 
                OddTriangle(x, y);

        }


        private static Triangle EvenTriangle(int x, int y)
        {
            return new Triangle(
                new Point { X = x * 10, Y = y * 10 },
                new Point { X = x * 10+10, Y = (y * 10) },
                new Point { X = x * 10 + 10, Y = (y * 10) + 10 });
        }

        private static Triangle OddTriangle(int x, int y)
        {
            return new Triangle(
                new Point { X = x * 10, Y = y * 10 },
                new Point { X = x * 10, Y = (y * 10)+10 },
                new Point { X = x * 10 + 10, Y = (y * 10) + 10});

        }

        public static string GetRowColumn(Point p1, Point p2, Point p3)
        {
            //point 1 is always the top left, and is the row
            var row = RowMapper.GetKey(p1.Y > 0 ? p1.Y/10 : p1.Y);
            int colum = (p3.X / 10)-1;
            //we can figure out if its even or odd by the second and third point x coor.
            if (p2.X == p3.X)
            {
                colum = (2 + (colum * 2));
            }
            else
            {
                colum = (1 + (colum * 2));
            }

            return $"{row}{colum}";
        }
    }
}