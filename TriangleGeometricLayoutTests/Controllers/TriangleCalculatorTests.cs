using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TriangleGeometricLayout.BLL;
using TriangleGeometricLayout.Controllers;

namespace TriangleGeometricLayoutTests.Controllers
{
    [TestClass]
    public class TriangleCalculatorTests
    {
        [TestMethod]
        public void CalculateTriangleTest()
        {
            foreach (var test in TestSets.Tests)
            {
                var triangle = TriangleCalculator.CalculateTriangle(test.Row, test.Column);
                var expectedJson = JsonConvert.SerializeObject(test.ExpectedResult);
                var actualJson = JsonConvert.SerializeObject(triangle);
                Assert.IsTrue(expectedJson == actualJson, $" For {test.Row}{test.Column} Expected: {expectedJson}, Actual: {actualJson}");
            }
        }
    }

    public static class TestSets
    {
        public static List<TestSet> Tests = new List<TestSet>
        {
            new TestSet
            {
                Row = "A",
                Column = 1,
                ExpectedResult = new Triangle(
                    new Point { X = 0, Y = 0 },
                    new Point { X = 0, Y = 10 },
                    new Point { X = 10, Y = 10 })
            },
            new TestSet
            {
                Row = "A",
                Column = 2,
                ExpectedResult = new Triangle(
                    new Point { X = 0, Y = 0 },
                    new Point { X = 10, Y = 0 },
                    new Point { X = 10, Y = 10 })
            },
            new TestSet
            {
                Row = "A",
                Column = 12,
                ExpectedResult = new Triangle(
                    new Point { X = 50, Y = 0 },
                    new Point { X = 60, Y = 0 },
                    new Point { X = 60, Y = 10})
            },
            new TestSet
            {
                Row = "F",
                Column = 1,
                ExpectedResult = new Triangle(
                    new Point { X = 0, Y = 50 },
                    new Point { X = 0, Y = 60 },
                    new Point { X = 10, Y = 60})
            },
            new TestSet
            {
                Row = "F",
                Column = 2,
                ExpectedResult = new Triangle(
                    new Point { X = 0, Y = 50 },
                    new Point { X = 10, Y = 50 },
                    new Point { X = 10, Y = 60})
            },
            new TestSet
            {
                Row = "F",
                Column = 11,
                ExpectedResult = new Triangle(
                    new Point { X = 50, Y = 50 },
                    new Point { X = 50, Y = 60 },
                    new Point { X = 60, Y = 60})
            },
            new TestSet
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

    public class TestSet
    {
        public int Column;
        public string Row;

        public Triangle ExpectedResult;
    }
}