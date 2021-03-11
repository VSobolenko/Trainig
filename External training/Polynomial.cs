using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_training
{
    public class Polynomial
    {

        int[] koef;
        int step;

        public Polynomial(int[] k, int s)
        {
            koef = k;
            step = s;
        }

        public override bool Equals(object obj)
        {
            return obj is Polynomial polynomial &&
                   step == polynomial.step &&
                   Enumerable.SequenceEqual(koef, polynomial.koef);
        }

        public override int GetHashCode()
        {
            int hashCode = -644138553;
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(koef);
            hashCode = hashCode * -1521134295 + step.GetHashCode();
            return hashCode;
        }

        public void Show()
        {
            foreach(var index in koef)
            {
                Console.WriteLine(index);
            }
            Console.WriteLine("-----" + step);
        }

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

        public static Polynomial operator /(Polynomial A, Polynomial B)
        {
            int D1 = A.step;
            int[] M1 = new int[D1 + 1];
            Polynomial C = new Polynomial(M1, D1);
            for (int i = 0; i < A.step + 1; i++)
            {
                C.koef[i] = A.koef[i] / B.koef[i];
            }
            return C;
        }
    }
}
