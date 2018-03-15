using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undying.Tests
{
    [TestClass]
    public class MainWindowTests
    {
        Triangle obj;
        /*
         *  equilateral
            isosceles
            not equilateral
         */
        [TestMethod]
        public void Equilateral_Data()
        {
            obj = new Triangle("4", "4", "4");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник равносторонний.");
        }

        [TestMethod]
        public void Isosceles_Data()
        {
            obj = new Triangle("12", "12", "20");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник равнобедренный.");
        }

        [TestMethod]
        public void NotEquilateral_Data()
        {
            obj = new Triangle("6", "8", "10");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник неравносторонний.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeNumber_Data()
        {
            obj = new Triangle("-3", "-5", "-5");
            obj.GetTriangleType();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void OverflowNumber_Data()
        {
            obj = new Triangle("10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000", "1", "1");
            obj.GetTriangleType();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Symbols_Data()
        {
            obj = new Triangle("aaa", "fff", "ddd");
            obj.GetTriangleType();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Null_Data()
        {
            obj = new Triangle("", "", "");
            obj.GetTriangleType();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidTriangle_Data()
        {
            obj = new Triangle("1", "1000", "1");
            obj.GetTriangleType();
            Assert.IsTrue(true);
        }
    }
}
