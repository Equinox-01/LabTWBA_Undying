using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undying.Tests
{
    [TestClass]
    public class MainWindowTests
    {
        Triangle obj;

        [TestMethod]
        public void Valid_Data()
        {
            obj = new Triangle("6", "8", "10");
            var result = obj.GetTriangleType();
            Assert.IsTrue(result != "");
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
