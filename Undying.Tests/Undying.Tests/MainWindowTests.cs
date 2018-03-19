using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undying.Tests
{
    [TestClass]
    public class MainWindowTests
    {
        Triangle obj;
        //Минимальные значения
        [TestMethod]
        public void Min_Equilateral_Data()
        {
            obj = new Triangle("1", "1", "1");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник равносторонний.");
        }

        [TestMethod]
        public void Min_Isosceles_Data()
        {
            obj = new Triangle("2", "2", "1");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник равнобедренный.");
        }

        [TestMethod]
        public void Min_NotEquilateral_Data()
        {
            obj = new Triangle("3", "4", "2");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник неравносторонний.");
        }
        //Максимальные значения
        [TestMethod]
        public void Max_Equilateral_Data()
        {
            obj = new Triangle("494967295", "494967295", "494967295");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник равносторонний.");
        }

        [TestMethod]
        public void Max_Isosceles_Data()
        {
            obj = new Triangle("494967295", "494967295", "494967294");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник равнобедренный.");
        }

        [TestMethod]
        public void Max_NotEquilateral_Data()
        {
            obj = new Triangle("494967295", "494967294", "494967293");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник неравносторонний.");
        }
        //Средние значения
        [TestMethod]
        public void Medium_Equilateral_Data()
        {
            obj = new Triangle("4", "4", "4");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник равносторонний.");
        }

        [TestMethod]
        public void Medium_Isosceles_Data()
        {
            obj = new Triangle("12", "12", "20");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result == "Треугольник равнобедренный.");
        }

        [TestMethod]
        public void Medium_NotEquilateral_Data()
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
            obj = new Triangle("4294967297", "1", "1");
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
