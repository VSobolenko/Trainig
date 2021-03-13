using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace External_training
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод текст
            //Console.Write("Введите ваше предложение: ");
            //string inputText = Console.ReadLine();
            string inputText = "У меня 10 долларов и 3 яблока.";

            //Разбиение введённого текста на отдельные слова для преобразования
            string[] splitText = inputText.Split(' ');
            string newText = "";

            //Отдельно каждое слово изменяем и сохраняем в новую строку
            for (int i = 0; i < splitText.Length; i++)
            {
                newText += MoveLettersInAWord(splitText[i]) + " ";
            }

            //Выводим старую и новую версию строки
            Console.WriteLine("Стары текст: {0}", inputText);
            Console.WriteLine("Новый текст: {0}", newText);
            Console.ReadKey();
        }

        static string MoveLettersInAWord(string text)
        {
            string newWord = "";

            //В передаваемом тексте записываем в начало гласные буквы, соглсано регулярному выражению
            Regex regex = new Regex("[уеёыаоэюияЁУЕЭОАЫЯИЮ]");
            MatchCollection match = regex.Matches(text);
            foreach (Match mtch in match)
            {
                Console.WriteLine(mtch.Value);
                newWord += mtch.Value;
            }

            //Аналогичное действие, только регулярное выражения отбрасывает все гласные буквы
            Regex regex2 = new Regex("[^уеёыаоэюияЁУЕЭОАЫЯИЮ]");
            match = regex2.Matches(text);
            foreach (Match mtch in match)
            {
                Console.WriteLine(mtch.Value);
                newWord += mtch.Value;
            }
            return newWord;
        }
    }
}
