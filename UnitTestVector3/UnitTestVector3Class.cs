using External_training;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace UnitTestVector3
{
    [TestClass]
    public class UnitTestVector3Class
    {
        [TestMethod]
        public void Distance_325And584_6_403124Returned()
        {
            Vector3 vector1 = new Vector3(3, 2, 5);
            Vector3 vector2 = new Vector3(5, 8, 4);

            double numerator = 3 * 5 + 2 * 8 + 5 * 4;
            double denumerator = Math.Sqrt(3 * 3 + 2 * 2 + 5 * 5) * Math.Sqrt(5 * 5 + 8 * 8 + 4 * 4);
            double angle = numerator / denumerator;
            Assert.AreEqual(angle, Vector3.Angle(vector1, vector2));
        }

        [TestMethod]
        public void Angle_325And584_0_80739Returned()
        {
            Vector3 vector1 = new Vector3(3, 2, 5);
            Vector3 vector2 = new Vector3(5, 8, 4);

            double denumerator = Math.Pow(5 - 3, 2) + Math.Pow(8 - 2, 2) + Math.Pow(4 - 5, 2);
            double distance = Math.Sqrt(denumerator);
            Assert.AreEqual(distance, Vector3.Distance(vector1, vector2));
        }

        [TestMethod]
        public void TestOperatorPlus_325And584_8_10_9_Returned()
        {
            Vector3 vector1 = new Vector3(3, 2, 5);
            Vector3 vector2 = new Vector3(5, 8, 4);
            Vector3 rezult = new Vector3(8, 10, 9);
            Assert.AreEqual(rezult, vector1 + vector2);
        }

        [TestMethod]
        public void TestOperatorMinus_325And584_z2_z6_1_Returned()
        {
            Vector3 vector1 = new Vector3(3, 2, 5);
            Vector3 vector2 = new Vector3(5, 8, 4);
            Vector3 rezult = new Vector3(-2, -6, 1);
            Assert.AreEqual(rezult, vector1 - vector2);
        }

        [TestMethod]
        public void TestOperatorMinusRevert_325_z3_z2_z5Returned()
        {
            Vector3 vector = new Vector3(3, 2, 5);
            Vector3 rezult = new Vector3(-3, -2, -5);
            Assert.AreEqual(rezult, -vector);
        }

        [TestMethod]
        public void TestOperatorMultiplication_325And3_9_6_15Returned()
        {
            Vector3 vector = new Vector3(3, 2, 5);
            Vector3 rezult = new Vector3(9, 6, 15);
            Assert.AreEqual(rezult, vector * 3);
        }

        [TestMethod]
        public void TestOperatorDivision_325And2_1o5_1_2o5Returned()
        {
            Vector3 vector = new Vector3(3, 2, 5);
            Vector3 rezult = new Vector3(1.5, 1, 2.5);
            Assert.AreEqual(rezult, vector / 2);
        }

        [TestMethod]
        public void TestOperatorComparison_325And584_false_2o5Returned()
        {
            Vector3 vector1 = new Vector3(3, 2, 5);
            Vector3 vector2 = new Vector3(5, 8, 4);
            Assert.AreEqual(false, vector1 == vector2);
        }

        [TestMethod]
        public void TestOperatorNotComparison_325And584_true_2o5Returned()
        {
            Vector3 vector1 = new Vector3(3, 2, 5);
            Vector3 vector2 = new Vector3(5, 8, 4);
            Assert.AreEqual(true, vector1 != vector2);
        }
    }
}