using System;
using MatbLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.UnitTests
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void Addition()
        {
            Assert.AreEqual(7, Functions.Add(3, 4));
        }
        [TestMethod]
        public void Subtraction()
        {
            Assert.AreEqual(6, Functions.Sub(10, 4));
        }
        [TestMethod]
        public void Muliplication()
        {
            Assert.AreEqual(72, Functions.Mul(8, 9));
        }
        [TestMethod]
        public void Division()
        {
            Assert.AreEqual(3, Functions.Div(15, 5));
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            Functions.Div(10, 0);
        }
    }
}
