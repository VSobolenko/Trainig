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
            }

            {
                
                Console.WriteLine("---------Задание 2---------");
                Console.Write("Введите точность: ");
                double accuracy = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите начало отрезка: ");
                double x0 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите конец отрезка: ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите шаг: ");
                double step = Convert.ToDouble(Console.ReadLine());
                /*
                double accuracy = 0.00001d;
                double x0 = 1d;
                double x = 10d;
                double step = 1d;
                */
                double s, y;
                uint i;
                const uint MaxIter = 500;
                bool done = true;
                Console.WriteLine(" __________________________________________________________");
                Console.WriteLine("|  x  |      Сумма ряда      |   n   |     Зн. функции     ");
                Console.WriteLine(" ==========================================================");
                while(x0 <= x)
                {
                    s = 1; y = s;
                    for(i = 1; Math.Abs(s) > accuracy; i++)
                    {
                        s *= -x0 * x0 / (2 * i * (2 * i - 1));
                        y += s;
                        if (i > MaxIter) { done = false; break; }
                    }
                    if (done) Console.WriteLine("{0,5} | {1,20} | {2,5} | {3,20}", x0, y, i, Math.Cos(x0));
                    else Console.WriteLine("|{0,5}|Ряд расходится| ");
                    x0 += step;
                }
                Console.ReadKey();
            }
        }
        private static void PrintRezult(float var, FunctionOnSegment func)
        {
            Console.WriteLine($"При x = {var}, y = {func(var)}");
        }
    }
}
