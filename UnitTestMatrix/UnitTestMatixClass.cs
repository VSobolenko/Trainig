using External_training;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatrix
{
    [TestClass]
    public class UnitTestMatixClass
    {

        [TestMethod]
        public void TestSum()
        {
            Matrix matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 4;

            Matrix matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 5;
            matrix2[0, 1] = 6;
            matrix2[1, 0] = 7;
            matrix2[1, 1] = 8;

            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 6;
            expected[0, 1] = 8;
            expected[1, 0] = 10;
            expected[1, 1] = 12;

            Matrix actual = Matrix.Sum(matrix1, matrix2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSubstract()
        {
            Matrix matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 7;
            matrix1[0, 1] = 5;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 8;

            Matrix matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 1;
            matrix2[0, 1] = 3;
            matrix2[1, 0] = 2;
            matrix2[1, 1] = 1;

            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 6;
            expected[0, 1] = 2;
            expected[1, 0] = 1;
            expected[1, 1] = 7;

            Matrix actual = Matrix.Substract(matrix1, matrix2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            Matrix matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 7;
            matrix1[0, 1] = 5;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 8;

            Matrix matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 1;
            matrix2[0, 1] = 3;
            matrix2[1, 0] = 2;
            matrix2[1, 1] = 1;

            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 17;
            expected[0, 1] = 26;
            expected[1, 0] = 19;
            expected[1, 1] = 17;

            Matrix actual = Matrix.Multiplication(matrix1, matrix2);
            Assert.AreEqual(expected, actual);
        }
    }
}
