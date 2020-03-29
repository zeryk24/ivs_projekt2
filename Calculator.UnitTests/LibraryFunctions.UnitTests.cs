using System;
using MatbLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.UnitTests
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void Add_BasicInput()
        {
            Assert.AreEqual(8.0303, Functions.Add(3.798, 4.2323));
        }
        [TestMethod]
        public void Add_Overflow()
        {
            Assert.IsTrue(Double.IsInfinity(Functions.Add(Double.MaxValue, Double.MaxValue)));
        }
        [TestMethod]
        public void Sub_BasicInput()
        {
            Assert.AreEqual(6.32761, Functions.Sub(10.56748, 4.23987));
        }
        [TestMethod]
        public void Sub_Underflow()
        {
            Assert.IsTrue(Double.IsInfinity(Functions.Sub(Double.MinValue, Double.MaxValue)));
        }

        [TestMethod]
        public void Mul_BasicInput()
        {
            Assert.AreEqual(-76.48, Functions.Mul(8, -9.56));
        }
        [TestMethod]
        public void Mul_Overflow()
        {
            Assert.IsTrue(Double.IsInfinity(Functions.Mul(Double.MinValue, 2)));

        }
        [TestMethod]
        public void Div_BasicInput()
        {
            Assert.AreEqual(3, Functions.Div(15, 5));
        }
        [TestMethod]
        public void Div_BasicInput2()
        {
            Assert.IsTrue(Math.Abs(0.7142857 - Functions.Div(5, 7)) <= (Functions.Div(5, 7) * 0.0000001));
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Div_DivideByZero()
        {
            Functions.Div(10, 0);
        }
        [TestMethod]
        public void Fact_BasicInput()
        {
            Assert.AreEqual(120, Functions.Fact(5));
        }
        [TestMethod]
        public void Fact_Zero()
        {
            Assert.AreEqual(1, Functions.Fact(0));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Fact_InvalidInput()
        {
            Functions.Fact(-5);
        }
        [TestMethod]
        public void Fact_Overflow()
        {
            Assert.IsTrue(Double.IsInfinity(Functions.Fact(600)));
        }
        [TestMethod]
        public void Exp_BasicInput()
        {
            Assert.AreEqual(64, Functions.Exp(4,3));
        }
        [TestMethod]
        public void Exp_ZeroExp()
        {
            Assert.AreEqual(1, Functions.Exp(22, 0));
        }
        [TestMethod]
        public void Exp_ZeroBase()
        {
            Assert.AreEqual(0, Functions.Exp(0, 5));
        }
        [TestMethod]
        public void Exp_NegativeBase()
        {
            Assert.AreEqual(Math.Abs(Functions.Exp(-5, 6)), (Functions.Exp(5, 6)));
        }
        [TestMethod]
        public void Exp_NegativeExp()
        {
            Assert.AreEqual(Functions.Exp(6, -4), 1/(Functions.Exp(6, 4)));
        }
        [TestMethod]
        public void Root_BasicInput()
        {
            Assert.AreEqual(6, Functions.Root(1296, 4));
        }
        [TestMethod]
        public void Root_BasicInput2()
        {
            Assert.IsTrue(Math.Abs(1.75256345 - Functions.Root(89, 8)) <= 1.75256345 * 0.00000001);
        }
        [TestMethod]
        public void Root_ZeroBase()
        {
            Assert.AreEqual(0, Functions.Root(0, 4));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Root_ZeroDegree()
        {
            Functions.Root(5, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void Root_InvalidInput()
        {
            Functions.Root(-5, 2);
        }
        [TestMethod]
        public void Root_Exp_Equal()
        {
            Assert.AreEqual(Functions.Exp(125, 1/3.0), Functions.Root(125,3));
        }
        [TestMethod]
        public void NatLog_BasicInput()
        {
            Assert.AreEqual(1, Functions.NatLog(Math.E));
        }
        [TestMethod]
        public void NatLog_BasicInput2()
        {
            Assert.IsTrue(Math.Abs(4.49980967 - Functions.NatLog(90)) <= 4.49980967 * 0.00000001);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NatLog_ZeroInput()
        {
            Functions.NatLog(0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NatLog_NegativeInput()
        {
            Functions.NatLog(-5);
        }

    }
}
