using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_training
{
    class Program
    {
        delegate float FunctionOnSegment(float func);

        static void Main(string[] args)
        {
            Console.WriteLine("---------Задание 1---------");
            float userInput;

            //Ввод переменной x
            Console.Write("Введите x: ");
            Single.TryParse(Console.ReadLine(), out userInput);

            //Смотря на какой участок функции попадает x выполняется определённая функция f(x)
            if (userInput >= -6 && userInput < -4)
            {
                PrintRezult(userInput, x => -2f);
            }
            else if (userInput >= -4 && userInput <= 0)
            {
                PrintRezult(userInput, x => x / 2f);
            }
            else if (userInput > 0 && userInput <= 2)
            {
                PrintRezult(userInput, x => x * x);
            }
            else if (userInput > 2 && userInput <= 12)
            {
                PrintRezult(userInput, x => -x / 2f + 5f);
            }
            else
            {
                Console.WriteLine("Вы вышли за пределы функции");
            }


            Console.WriteLine("---------Задание 2---------");
            Console.Write("Введите точность: ");
            double ep = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите начало отрезка: ");
            double z = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите конец отрезка: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите шаг: ");
            double h = Convert.ToDouble(Console.ReadLine());

            double s, y;
            const int MaxIter = 500;
            bool done = true;
            int i;
            Console.WriteLine(" _______________________");
            Console.WriteLine("|x|Сумма ряда|n|]Зн. функции|");
            Console.WriteLine(" ________________________");
            while (z <= b)
            {
                s = 1; y = s;
                done = true;
                for (i = 1; Math.Abs(s) > ep; i++)
                {
                    s = s * (z / i);
                    y = y + s;
                    if (i > MaxIter) { done = false; break; }
                }
                if (done == true) Console.WriteLine("|{0,5}|{1,18}|{2,5}|{3,18}| ", z, y, i, Math.Exp(z));
                else Console.WriteLine("|{0,5}|Ряд расходится| ", z);
                z = z + h;

            }
            Console.ReadKey();
        }
        private static void PrintRezult(float var, FunctionOnSegment func)
        {
            Console.WriteLine($"При x = {var}, y = {func(var)}");
        }
    }
}
