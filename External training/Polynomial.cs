using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_training
{
    class Polynomial
    {

        int[] koef; //массив коэф-ов
        int step; //значение степени полинома

        public Polynomial(int[] k, int s)
        {
            koef = k;
            step = s;
        }

        //сложение полиномов
        public static Polynomial operator +(Polynomial A, Polynomial B)
        {
            int D1 = A.step;
            int[] M1 = new int[D1 + 1];
            Polynomial C = new Polynomial(M1, D1);
            for (int i = 0; i < A.step + 1; i++)
            {
                C.koef[i] = A.koef[i] + B.koef[i];
            }
            return C;
        }


        //вычитание полиномов
        public static Polynomial operator -(Polynomial A, Polynomial B)
        {
            int D1 = A.step;
            int[] M1 = new int[D1 + 1];
            Polynomial C = new Polynomial(M1, D1);
            for (int i = 0; i < A.step + 1; i++)
            {
                C.koef[i] = A.koef[i] - B.koef[i];
            }
            return C;
        }


        //умножение полиномов
        public static Polynomial operator *(Polynomial A, Polynomial B)
        {
            int D1 = A.step;
            int[] M1 = new int[D1 + 1];
            Polynomial C = new Polynomial(M1, D1);
            for (int i = 0; i < A.step + 1; i++)
            {
                C.koef[i] = A.koef[i] * B.koef[i];
            }
            return C;
        }
    }
}
