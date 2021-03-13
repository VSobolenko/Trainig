using System;
using System.Linq;
using System.Collections.Generic;

namespace External_training
{
    class Program
    {
        static void Main(string[] args)
        {
            //новый тест
            //Ввод текст
            Console.Write("Введите ваше предложение: ");
            string inputText = Console.ReadLine();

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

        //Метод, который в словах гласные буквы выносит в начало слова, сохранив порядок
        static string MoveLettersInAWord(string text)
        {
            //Тут храним наши букву, которые мы считаем что они являются гласными
            var constVowels = new List<char>() { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };

            //Массив хранящий наше 1 слово в виде символов
            char[] letters = text.ToCharArray();

            //2 массива, которые отдельно хранят гласные и согласные буквы, сохраняя их порядок как и в слове
            char[] vowels = new char[text.Length];
            char[] consonants = new char[text.Length];

            //Собственный индекс для массива символов
            int jvow = 0;
            int jcons = 0;

            string newWord = "";

            //Разделяем слово на 2 массива гласных и согласных букв
            for (int i =0; i< letters.Length; i++)
            {
                if(constVowels.Contains(letters[i]))
                {
                    vowels[jvow] = letters[i];
                    jvow++;
                }
                else
                {
                    consonants[jcons] = letters[i];
                    jcons++;
                }
            }

            //Соединяем 2 массива в новое слово, сначала гласные, потом согласные. Порядок сохранятся
            foreach (var index in vowels.Where(x=>x != '\0'))
            {
                newWord += index.ToString();
            }
            foreach (var index in consonants.Where(x=> x != '\0'))
            {
                newWord += index.ToString();
            }

            return newWord;
        }
    }
}
