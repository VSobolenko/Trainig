using System;
using System.Linq;

namespace External_training
{
    class Program
    {
        struct Dishes
        {
            public string name;
            public string material;
            public string type;
            public int price1, price2, price3;
        }
        static void Main(string[] args)
        {
            bool newSwitch = true;

            uint n = 9, m = 4;
            int s = 0;

            Console.WriteLine("Для одномерного массива, где N - его размер, введите N");
            VariableInitialization(ref n);
            Console.WriteLine("Для двумерного массива N x M, где N=" + n + ", введите M");
            VariableInitialization(ref m);

            int[] ex1 = new int[n];
            int[,] ex2 = new int[n, m];

            ArrayInitialization(ref ex1, ref s);
            ArrayInitialization(ref ex2, ref s);

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
                        Console.WriteLine("\nДля передачи по значению возспользуемся методом, находящий сумму модулей массива\nВыполняется...");
                        Console.WriteLine("...Готово!\nСумма элементов массива до элемента S=" + s + " равна: " + SumOfElementArrayRef(ref ex2, ref s));
                        break;

                    case 2:
                        Console.WriteLine("\nДля передачи по ссылке возспользуемся методом, сортирующий массив до последнего чётного элемента\nВыполняется...");
                        SortArrayWithRef(ref ex1);
                        Console.WriteLine("...Готово!\nОтсортированный массив по убыванию до последнего четного элемента: ");
                        PrintToConsoleArray(ref ex1);
                        break;

                    case 3:
                        Console.WriteLine("\nДля того, чтобы возвользоваться выходынми параметрами и параметром-массивом возспользуемся методом, " +
                                                   "находящий номер последней строки с хотя бы 1 нечётным числом\nВыполняется..");
                        int? latLineWithOddNumber = null;
                        LastStringWithOddNumber(out latLineWithOddNumber, ex1);
                        Console.WriteLine("\nНомер последней строки где встречается нечетное число: " + latLineWithOddNumber);

                        break;
                    case 4:
                        Console.WriteLine("4");
                        break;
                    case 5:
                        newSwitch = false;
                        break;
                    default:
                        Console.WriteLine("\nВведены не корректные данные, нужна ещё 1 попытка");
                        break;
                }

            }

            //Задание 2 - отсортировать по убыванию до последнего чётного элемента

            //Задание 3 - номер последней строки с хотя бы 1 нечётным числом

            Console.ReadKey();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nМеню:");
            Console.Write("1 - передать данные по значению" + "\n" +
                "2 - передать данные по ссылке" + "\n" +
                "3 - использовать выходные параметры" + "\n" +
                "4 - использовать параметры массивы" + "\n" +
                "5 - выйти из программы" + "\n" +
                "Ваш выбор: ");
        }
        private static void LastStringWithOddNumber(out int? latLineWithOddNumber, params int[] ex2)
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
        private static void SortArrayWithRef(ref int[] arr)
        {
            arr = arr.TakeWhile(x => x % 2 == 0).OrderByDescending(x => x).ToArray();
        }
        private static double SumOfElementArrayRef(ref int[,] ex1, ref int s)
        {
            bool beginCounting = false;
            double sumOfElements = 0;
            for (int i = 0; i < ex1.GetLength(0); i++)
            {
                for (int j = 0; j < ex1.GetLength(1); j++)
                {
                    if (ex1[i, j] == s && beginCounting == false)
                    {
                        beginCounting = true;
                        continue;
                    }
                    if (beginCounting)
                    {
                        sumOfElements += Math.Abs(ex1[i, j]);
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
                    //size = SelectionMenu(ref size);
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Введены не корректные данные, нужна ещё 1 попытка");
                }
            }
        }
        static void VariableInitialization(ref int size)
        {
            while (true)
            {
                try
                {
                    Console.Write("Ваш выбыор: ");
                    size = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Введены не корректные данные, нужна ещё 1 попытка");
                }
            }
        }
        static void PrintToConsoleArray(ref int[] array)
        {
            foreach (float index in array)
            {
                Console.Write(index + " ");
            }
        }
        static void ArrayInitialization(ref int[] array, ref int constVar)
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
                array[i] = rand.Next(0,100);
            }
        }
        static void PrintToConsoleArray(ref int[,] array)
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
        static void ArrayInitialization(ref int[,] array, ref int constS)
        {
            Random rand = new Random();
            int randomPositionX = rand.Next(0, array.GetLength(0));
            int randomPositionY = rand.Next(0, array.GetLength(1));
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(0, 100);
                    if (i == randomPositionX && j == randomPositionY)
                    {
                        array[i, j] = constS;
                    }
                }
            }
        }
    }
}
