using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_training
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = 3, m = 4;
            /*
            Console.WriteLine("Для одномерного массива, где N - его размер, введите N");
            EnteringDimensionArray(ref n);
            Console.WriteLine("Для двумерного массива N x M, где N=" + n + ", введите M");
            EnteringDimensionArray(ref m);
            */

            double[] ex1 = new double[n];
            double[,] ex2 = new double[n, m];

            ArrayInitialization(ref ex1);
            PrintToConsoleArray(ref ex1);
            Console.WriteLine("-------------");
            ArrayInitialization(ref ex2);
            PrintToConsoleArray(ref ex2);
            Console.ReadKey();
        }
        static void EnteringDimensionArray(ref uint size)
        {
            while (true)
            {
                try
                {
                    Console.Write("Ваш выбыор: ");
                    size = Convert.ToUInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Введены не корректные данные, нужна ещё 1 попытка");
                }
            }
        }

        static void PrintToConsoleArray(ref double[] array)
        {
            foreach (float index in array)
            {
                Console.WriteLine(index);
            }
        }

        static void ArrayInitialization(ref double[] array)
        {
            Random rand = new Random();
            int zero = rand.Next(0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
            {
                if(zero == i)
                {
                    array[i] = 0;
                    continue;
                }
                array[i] = rand.NextDouble() * 5;
            }
        }
        static void PrintToConsoleArray(ref double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0,10:F7} ", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void ArrayInitialization(ref double[,] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.NextDouble() * 10;
                }
            }
        }
    }
}
