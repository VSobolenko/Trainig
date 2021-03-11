using System;
using System.Threading;

namespace External_training
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(2, 2);
            matrix.InitializationAuto();
            matrix.PrintMatrix();
            Thread.Sleep(1000);
            Matrix matrix2 = new Matrix(2, 2);
            matrix2.InitializationAuto();
            matrix2.PrintMatrix();

            Matrix.Multiplication(matrix, matrix2).PrintMatrix();
            Console.ReadKey();
        }
    }
}
