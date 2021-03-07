using System;
using System.Linq;

namespace External_training
{
    class Program
    {
        static void Main(string[] args)
        {
            bool newSwitch = true;

            uint n = 9, m = 4;
            double s = 0;

            Console.WriteLine("Для одномерного массива, где N - его размер, введите N");
            VariableInitialization(ref n);
            Console.WriteLine("Для двумерного массива N x M, где N=" + n + ", введите M");
            VariableInitialization(ref m);

            double[] ex1 = new double[n];
            double[,] ex2 = new double[n, m];

            ArrayInitialization(ref ex1, ref s);
            ArrayInitialization(ref ex2);

            Console.WriteLine("\nВывод массива ex1:");
            PrintToConsoleArray(ref ex1);
            Console.WriteLine("\nВывод массива ex2:");
            PrintToConsoleArray(ref ex2);

            while (newSwitch)
            {
                uint userSelection = 0;

                PrintMenu();
                VariableInitialization(ref userSelection);

                switch (userSelection)
                {
                    case 1:
                        Console.WriteLine("Для передачи по значению возспользуемся методом находящий сумму модулей массива\nВыполняется...");
                        Console.WriteLine("...Готово!\nСумма элементов массива до элемента S=" + s + " равна: " + SumOfElementArrayRef(ref ex2, ref s));
                        break;

                    case 2:
                        Console.WriteLine("Для передачи по ссылке возспользуемся методом, сортирующий массив до последнего чётного элемента\nВыполняется..\n");
                        SortArrayWithRef(ref ex1);
                        Console.WriteLine("...Готово!\nОтсортированный массив по убыванию до последнего четного элемента: ");
                        PrintToConsoleArray(ref ex1);
                        break;

                    case 3:
                        Console.WriteLine("Для того, чтобы возвользоваться выходынми параметрами и параметром-массивом возспользуемся методом, " +
                                                   "находящий номер последней строки с хотя бы 1 нечётным числом\nВыполняется..\n");
                        int? latLineWithOddNumber = null;
                        LastStringWithOddNumber(out latLineWithOddNumber, ex1);
                        Console.WriteLine("Номер последней строки где встречается нечетное число: " + latLineWithOddNumber);

                        break;
                    case 4:
                        Console.WriteLine("4");
                        break;
                    case 5:
                        newSwitch = false;
                        break;
                    default:
                        Console.WriteLine("def");
                        break;
                }

            }

            //Задание 2 - отсортировать по убыванию до последнего чётного элемента

            //Задание 3 - номер последней строки с хотя бы 1 нечётным числом

            Console.ReadKey();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.Write("1 - передать данные по значению" + "\n" +
                "2 - передать данные по ссылке" + "\n" +
                "3 - использовать выходные параметры" + "\n" +
                "4 - использовать параметры массивы" + "\n" +
                "5 - выйти из программы" + "\n" +
                "Ваш выбор: ");
        }
        private static void LastStringWithOddNumber(out int? latLineWithOddNumber, params double[] ex2)
        {
            latLineWithOddNumber = 0;

            for (int i = 0; i < ex2.GetLength(0); i++)
            {
                if (ex2[i] % 2 == 0)
                {
                    latLineWithOddNumber = i;
                }
            }
        }

        private static void SortArrayWithRef(ref double[] arr)
        {
            arr = arr.TakeWhile(x => x % 2 == 0).OrderByDescending(x => x).ToArray();
        }
        private static double SumOfElementArrayRef(ref double[,] ex1, ref double s)
        {
            bool beginCounting = false;
            double sumOfElements = 0;
            for (int i = 0; i < ex1.Length; i++)
            {
                for(int j =0; j < ex1.Length; j++)
                {
                    if (ex1[i,j] == s && beginCounting == false)
                    {
                        beginCounting = true;
                        continue;
                    }
                    if (beginCounting)
                    {
                        sumOfElements += Math.Abs(ex1[i,j]);
                    }
                }
            }
            return sumOfElements;
        }
        private static uint SelectionMenu(ref uint variable)
        {
            if (variable > 0 && variable < 6)
            {
                return variable;
            }
            else
            {
                throw new Exception();
            }
        }
        static void VariableInitialization(ref uint size)
        {
            while (true)
            {
                try
                {
                    Console.Write("Ваш выбыор: ");
                    size = Convert.ToUInt32(Console.ReadLine());
                    size = SelectionMenu(ref size);
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
        static void ArrayInitialization(ref double[] array, ref double constVar)
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
