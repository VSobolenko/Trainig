using System;
using System.Linq;

namespace External_training
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = 9, m = 4;
            double s = 0;

            Console.WriteLine("Для одномерного массива, где N - его размер, введите N");
            VariableInitialization(ref n);
            Console.WriteLine("Для двумерного массива N x M, где N=" + n + ", введите M");
            VariableInitialization(ref m);
            //На случай если надо будет сравнивать не с 0 а с другим числом - задаётся переменной S
            //Console.WriteLine("Для одномерного массива, введите число S, после которого будет считаться сумма элементов");
            //VariableInitialization(ref s);

            //Задание не корреткно, т.к. нельзя проверить вещественное число на чётно/нечётность
            //Если вместо double использовать int программа работает корректно
            double[] ex1 = new double[n];
            double[,] ex2 = new double[n, m];

            //Заполнение массива случайными числами
            ArrayInitialization(ref ex1, s);
            ArrayInitialization(ref ex2);

            //Вывод результатов
            Console.WriteLine("\nВывод массива ex1:");
            PrintToConsoleArray(ref ex1);
            Console.WriteLine("\nВывод массива ex2:");
            PrintToConsoleArray(ref ex2);

            //Задание 1 - сумма модулей массива после элемента S
            bool beginCounting = false;
            double sumOfElements = 0;
            for (int i = 0; i < ex1.Length; i++)
            {
                if (ex1[i] == s)
                {
                    beginCounting = true;
                    continue;
                }
                if (beginCounting)
                {
                    sumOfElements += Math.Abs(ex1[i]);
                }
            }
            Console.WriteLine("Сумма элементов массива по элемента S=" + s + " равна: " + sumOfElements);

            //Задание 2 - отсортировать по убыванию до последнего чётного элемента
            ex1 = ex1.TakeWhile(x => x % 2 == 0).OrderByDescending(x => x).ToArray();
            Console.WriteLine("Отсортированный массив по убыванию до последнего четного элемента: ");
            PrintToConsoleArray(ref ex1);

            //Задание 3 - номер последней строки с хотя бы 1 не чётным числом
            int? latLineWithOddNumber = null;
            for (int i = 0; i < ex2.GetLength(0); i++)
            {
                for (int j = 0; j < ex2.GetLength(1); j++)
                {
                    if (ex2[i, j] % 2 == 0)
                        latLineWithOddNumber = i;
                }
            }
            Console.WriteLine("Номер последней строки где встречается нечетное число: " + latLineWithOddNumber);
            Console.ReadKey();
        }
        static void VariableInitialization(ref uint size)
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
        static void VariableInitialization(ref double size)
        {
            while (true)
            {
                try
                {
                    Console.Write("Ваш выбыор: ");
                    size = Convert.ToDouble(Console.ReadLine());
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
                Console.Write(index + " ");
            }
        }
        static void ArrayInitialization(ref double[] array, double constVar)
        {
            Random rand = new Random();
            int randomPosition = rand.Next(0, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                if (randomPosition == i)
                {
                    array[i] = constVar;
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
            int zero = rand.Next(0, array.Length);
            //int zero = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.NextDouble() * 10;
                }
            }
        }
    }
}
