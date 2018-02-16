using System;
using TriangleGeometricLayout.BLL.Abstract;
using TriangleGeometricLayout.BLL.Mappers;
using TriangleGeometricLayout.Controllers;
using TriangleGeometricLayout.Domain;

namespace TriangleGeometricLayout.BLL.Concrete
{
    public class TriangleCalculator : ITriangleCalculator
    {
        /// <summary> The scale of the triangles is 10 per the documentation. </summary>
        private const int Scale = 10;

        public Triangle CalculateTriangle(string row, int column)
        {
            var x = ConvertColumnToInt(column);
            var y = RowMapper.GetValue(row);

            //The only point that will differ for a triangle is the 2nd point.
            var p2 = column % 2 == 0
                ? new Point {X = x * Scale + Scale, Y = y * Scale}
                : new Point {X = x * Scale, Y = y * Scale + Scale};

            return new Triangle(
                new Point {X = x * Scale, Y = y * Scale},
                p2,
                new Point {X = x * Scale + Scale, Y = y * Scale + Scale});
        }

        /// <summary>
        ///     The first and second columns in a pair (0,1) (1,2) share the same top left starting point, for the ease of
        ///     calculations we will treat them the same from an x point of view.
        /// </summary>
        /// <param name="column"> The column in string format. </param>
        /// <returns> The column converted to int. </returns>
        private static int ConvertColumnToInt(int column) => 
            (int) Math.Ceiling((double) column / 2) - 1;

        
        /// <summary> Calculates the row and the colum from a set of points. </summary>
        ///
        /// <param name="p1"> The first Point. </param>
        /// <param name="p2"> The second Point. </param>
        /// <param name="p3"> The third Point. </param>
        ///
        /// <returns> The row column. </returns>
        public string GetRowColumn(Point p1, Point p2, Point p3)
        {
            //Point 1 is always the top left, and is the row
            var row = RowMapper.GetKey(p1.Y > 0 ? p1.Y / Scale : p1.Y);

            //We need to convert the column back to a zero index.
            var colum = p3.X / Scale - 1;

            //we can figure out if its even or odd triangle by the second and third point x coor being the same.
            colum = p2.X == p3.X ? 
                2 + colum * 2 : 
                1 + colum * 2;

            return $"{row}{colum}";
        }
    }
}