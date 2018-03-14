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
            obj = new Triangle();
            obj.GetTriangleType();
        }

        [TestMethod]
        public void NegativeNumber_Data()
        {

        }

        [TestMethod]
        public void OverflowNumber_Data()
        {

        }

        [TestMethod]
        public void Symbols_Data()
        {

        }

        [TestMethod]
        public void Null_Data()
        {

        }
    }
}
