using External_training;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}