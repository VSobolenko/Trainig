using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using External_training;

namespace UnitTestPolynomial
{
    [TestClass]
    public class UnitTestPolynomialClass
    {
        [TestMethod]
        public void TestOperatorPlus()
        {
            Polynomial polynomial1 = new Polynomial(new int[3] { 1, 2, 3 }, 2);
            Polynomial polynomial2 = new Polynomial(new int[3] { 1, 2, 3 }, 2);
            Polynomial expected = new Polynomial(new int[3] { 2, 4, 6 }, 2);
            Assert.AreEqual(expected, polynomial1 + polynomial2);
        }

        [TestMethod]
        public void TestOperatorMinus()
        {
            Polynomial polynomial1 = new Polynomial(new int[3] { 2, 4, 6 }, 2);
            Polynomial polynomial2 = new Polynomial(new int[3] { 1, 2, 3 }, 2);
            Polynomial expected = new Polynomial(new int[3] { 1, 2, 3 }, 2);
            Assert.AreEqual(expected, polynomial1 - polynomial2);
        }

        [TestMethod]
        public void TestOperatorDivision()
        {
            Polynomial polynomial1 = new Polynomial(new int[3] { 1, 2, 3 }, 2);
            Polynomial polynomial2 = new Polynomial(new int[3] { 1, 2, 3 }, 2);
            Polynomial expected = new Polynomial(new int[3] { 1, 1, 1 }, 2);
            Assert.AreEqual(expected, polynomial1 / polynomial2);
        }

        [TestMethod]
        public void TestOperatorMultiplication()
        {
            Polynomial polynomial1 = new Polynomial(new int[3] { 1, 2, 3 }, 2);
            Polynomial polynomial2 = new Polynomial(new int[3] { 1, 2, 3 }, 2);
            Polynomial expected = new Polynomial(new int[3] { 1, 4, 9 }, 2);
            Assert.AreEqual(expected, polynomial1 * polynomial2);
        }
    }
}
