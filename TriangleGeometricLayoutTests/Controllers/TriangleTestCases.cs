using System.Collections.Generic;
using TriangleGeometricLayout.Controllers;
using TriangleGeometricLayout.Domain;

namespace TriangleGeometricLayoutTests.Controllers
{
    public static class TriangleTestCases
    {
        public static List<TestTriangle> Tests = new List<TestTriangle>
        {
            new TestTriangle
            {
                Row = "A",
                Column = 1,
                ExpectedResult = new Triangle(
                    new Point { X = 0, Y = 0 },
                    new Point { X = 0, Y = 10 },
                    new Point { X = 10, Y = 10 })
            },
            new TestTriangle
            {
                Row = "A",
                Column = 2,
                ExpectedResult = new Triangle(
                    new Point { X = 0, Y = 0 },
                    new Point { X = 10, Y = 0 },
                    new Point { X = 10, Y = 10 })
            },
            new TestTriangle
            {
                Row = "A",
                Column = 12,
                ExpectedResult = new Triangle(
                    new Point { X = 50, Y = 0 },
                    new Point { X = 60, Y = 0 },
                    new Point { X = 60, Y = 10})
            },
            new TestTriangle
            {
                Row = "F",
                Column = 1,
                ExpectedResult = new Triangle(
                    new Point { X = 0, Y = 50 },
                    new Point { X = 0, Y = 60 },
                    new Point { X = 10, Y = 60})
            },
            new TestTriangle
            {
                Row = "F",
                Column = 2,
                ExpectedResult = new Triangle(
                    new Point { X = 0, Y = 50 },
                    new Point { X = 10, Y = 50 },
                    new Point { X = 10, Y = 60})
            },
            new TestTriangle
            {
                Row = "F",
                Column = 11,
                ExpectedResult = new Triangle(
                    new Point { X = 50, Y = 50 },
                    new Point { X = 50, Y = 60 },
                    new Point { X = 60, Y = 60})
            },
            new TestTriangle
            {
                Row = "F",
                Column = 12,
                ExpectedResult = new Triangle(
                    new Point { X = 50, Y = 50 },
                    new Point { X = 60, Y = 50 },
                    new Point { X = 60, Y = 60})
            }

        };
    }
}