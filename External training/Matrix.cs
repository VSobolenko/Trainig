using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_training
{
    public class Matrix
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
            if(i <= 0 || j <= 0)
            {
                throw new Exception("Длина строк или столбцов не может быть меньше нуля");
            }
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
        public override bool Equals(object obj)
        {

            return obj is Matrix matrix &&
                   IsEquals(_matrix, matrix._matrix);
        }
        private bool IsEquals(int[,] arr1, int[,] arr2)
        {
            bool isEqual = true;
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    if (arr1[i, j] != arr2[i, j])
                    {
                        isEqual = false;
                        break;
                    }
                }
            }
            return isEqual;
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
                    rezult[i, j] = a[i, j] - b[i, j];
                }
            }

            return rezult;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.i != b.j)
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }
            Matrix rezult = new Matrix(a.j, b.i);

            for (var i = 0; i < a.j; i++)
            {
                for (var j = 0; j < b.i; j++)
                {
                    rezult[i, j] = 0;

                    for (var k = 0; k < a.i; k++)
                    {
                        rezult[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return rezult;
        }
        public void Initialization()
        {
            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.WriteLine("Введите: a[{0}][{1}]", i, j);
                    _matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void InitializationAuto()
        {
            Random rand = new Random();
            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = rand.Next(0, 10);
                }
            }
        }
        public void PrintMatrix()
        {
            Console.WriteLine("Вывод матрицы: ");
            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", _matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
