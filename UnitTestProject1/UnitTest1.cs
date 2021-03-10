using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using External_training;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double r1 = Program.Average(1, 2, 3, 4);
            Assert.AreEqual(2.5, r1);
        }
    }
}