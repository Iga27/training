using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointLibrary;
using TriangleLibrary;

namespace TriangleLibrary.Tests
{
    [TestClass]
    public class TriangleTests
    {
        private Triangle tr;
        [TestInitialize]
        public void TestInitialize()
        {
            tr = new Triangle(new Point(1, 1), new Point(-2, 4), new Point(-2, -2));
        }
        [TestMethod]
        public void PerimeterTest()
        {
            double expected = 14.485;
            double delta = 0.01;

            double actual = tr.Perimeter();

            Assert.AreEqual(expected, actual, delta);
        }

        [TestMethod]
        public void SquareTest()
        {
            double expected = 9;
            double delta = 0.01;

            double actual = tr.Square();

            Assert.AreEqual(expected, actual, delta);
        }

        [ExpectedException(typeof(InvalidTriangleException), "Exception wasn't thrown")]
        [TestMethod]
        public void Perimeter_Exception_Test()
        {
            Triangle triangle = new Triangle(new Point(0, 0), new Point(0, 0), new Point(0, 0));

            double actual = triangle.Perimeter();
        }
    }
}
