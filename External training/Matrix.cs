using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_training
{
    class Matrix
    {
        /*
         (1,1)
               -------------> (j)
               |
               |
               |
               |
               V
               (i)

        */
        private int[,] _matrix;

        public Matrix()
        {
            _matrix = new int[2, 2];
        }
        public Matrix(int i, int j)
        {
            _matrix = new int[i, j];
        }

        public int i
        {
            get { return _matrix.GetLength(0); }
            private set { }
        }
        public int j
        {
            get { return _matrix.GetLength(1); }
            private set { }
        }

        public int this[int i, int j]
        {
            get { return _matrix[i, j]; }
            set { _matrix[i, j] = value; }
        }
        public static Matrix Sum(Matrix a, Matrix b)
        {
            return a + b;
        }
        public static Matrix Substract(Matrix a, Matrix b)
        {
            return a - b;
        }
        public static Matrix Multiplication(Matrix a, Matrix b)
        {
            return a * b;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix rezult = new Matrix(a.j, b.i);
            if ((a.i != b.i) || (a.j != b.j))
            {
                throw new Exception("Для матриц с разным размером сложение не возможно!");
            }

            for (var i = 0; i < a.j; i++)
            {
                for (var j = 0; j < b.i; j++)
                {
                    rezult[i, j] = a[i, j] + b[i, j];
                }
            }

            return rezult;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix rezult = new Matrix(a.j, b.i);
            if ((a.i != b.i) || (a.j != b.j))
            {
                throw new Exception("Для матриц с разным размером вычитание не возможно!");
            }

            for (var i = 0; i < a.j; i++)
            {
                for (var j = 0; j < b.i; j++)
                {
                    rezult[i, j] = a[i, j] + b[i, j];
                }
            }

            return rezult;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if(a.i != b.j)
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }
            Matrix rezult = new Matrix(a.j, b.i);

            for (var i = 0; i < a.j; i++)
            {
                for (var j = 0; j < b.i; j++)
                {
                    rezult[i, j] = 0;

                    for (var k = 0; k <a.i; k++)
                    {
                        rezult[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return rezult;
        }
    }
}
