using System;
using System.Collections.Generic;
using System.Linq;

namespace External_training
{
    class Rectangle
    {
        //Каждый прямоугольник имеет свою точку отсчёта, а так же его ширину и выстоту
        private int _x, _y; //Координаты (x,y)
        private int _width, _height; //Длина - по Ox, ширина - по Oy

        //Храним коллекцию кортежей, кторые представляют из себя информацию для конкретной точки ( длина от начала координат, до точки
        //и те самые точки, которые являются 1-м из углов прямоугольника
        private List<Tuple<double, int, int>> _vertices = null;
        public Rectangle()
        {
            _x = 0;
            _y = 0;
            _height = 10;
            _width = 5;
        }
        public Rectangle(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Width
        {
            get { return _width; }
            set
            {
                if (value > 0)
                    _width = value;
                else
                    Console.WriteLine("Невозможно выполнить данное действие");
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                if (value > 0)
                    _height = value;
                else
                    Console.WriteLine("Невозможно выполнить данное действие");
            }
        }

        //Установить новую позицию
        public void SetNewPosition(int x, int y)
        {
            _x = x;
            _y = y;
        }

        //Установить новый размер, а именно ширину и высоту
        public void SetNewSize(int width, int heifht)
        {
            if(width > 0 && heifht > 0)
            {
                _width = width;
                _height = heifht;
            }
            else
            {
                Console.WriteLine("Невозможно выполнить данное действие");
            }
        }

        //Метод принимает полные данные 1-го и 2-го прямоугольника и находит минимальный прямоугольник,
        //который содержит внутри себя 2 заданных прямоугольника
        public void MinimalRectangle(int x1, int y1, int x2, int y2, int width1, int height1, int width2, int height2)
        {
            /*
                Item1 - длина от точки (0,0), до точки (x,y) 
                Item2 - координата x
                Item3 - координата y
             */

            //Добавляем новые данные по углам
            _vertices = new List<Tuple<double, int, int>>();
            _vertices.Add(Tuple.Create(Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)), x1, y1));
            _vertices.Add(Tuple.Create(Math.Sqrt(Math.Pow(x1 + width1, 2) + Math.Pow(y1 + height1, 2)), x1 + width1, y1 + height1));

            _vertices.Add(Tuple.Create(Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)), x2, y2));
            _vertices.Add(Tuple.Create(Math.Sqrt(Math.Pow(x2 + width2, 2) + Math.Pow(y2 + height2, 2)), x2 + width2, y2 + height2));

            //Проверяем что такие прямоугольники существуют
            bool hasRectangle = HasRectangle(_vertices[0], _vertices[1], _vertices[2], _vertices[3]);

            var minCoordinates = _vertices.Min();
            var maxCoordinates = _vertices.Max();

            //PrintTableCoordinates(_vertices);

            if (hasRectangle)
            {
                Console.WriteLine("\nНайдём минимальный прямоугольник, содержащий 2 заданных прямоугольника..." +
                "\nЕго координаты:\n  x1 |  y1 |  x2 | y2 \n=========================");
                Console.WriteLine("  " + minCoordinates.Item2 + "  |  " + minCoordinates.Item3 + "  |  " +
                    maxCoordinates.Item2 + "  |  " + maxCoordinates.Item3);
            }
            else
            {
                Console.WriteLine("Введённые параметры не корректны или такого прямоугольника не существует _");
            }
        }

        //Отображение полной таблицы координатов
        private void PrintTableCoordinates(List<Tuple<double, int, int>> coord)
        {
            Console.WriteLine("Таблица координатов:\n diagonal |   x  |    y  ");
            Console.WriteLine("=========================");
            foreach (var index in coord)
            {
                Console.WriteLine("{0,9:F5} | {1,4} | {2,4}", index.Item1, index.Item2, index.Item3);
            }
        }

        //Метод принимает полные данные 1-го и 2-го прямоугольника и находит минимальный прямоугольник,
        //который является пересечением 2-х заданных прямоугольников
        public void CrossRectangle(int x1, int y1, int x2, int y2, int width1, int height1, int width2, int height2)
        {
            _vertices = new List<Tuple<double, int, int>>();
            _vertices.Add(Tuple.Create(Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)), x1, y1));
            _vertices.Add(Tuple.Create(Math.Sqrt(Math.Pow(x1 + width1, 2) + Math.Pow(y1 + height1, 2)), x1 + width1, y1 + height1));

            _vertices.Add(Tuple.Create(Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)), x2, y2));
            _vertices.Add(Tuple.Create(Math.Sqrt(Math.Pow(x2 + width2, 2) + Math.Pow(y2 + height2, 2)), x2 + width2, y2 + height2));

            //Проверяем что введённые прямоугольники существуют
            bool hasRectangle = HasRectangle(_vertices[0], _vertices[1], _vertices[2], _vertices[3]);
            //Проверям что существую прямоугольник созданный пересечением 
            hasRectangle = HasCrossRectangle(_vertices[0], _vertices[1], _vertices[2], _vertices[3]);

            var coordinatesRectangle = _vertices.Where(x => x != _vertices.Min() && x != _vertices.Max());
            var minNewCoordinates = coordinatesRectangle.Min();
            var maxNewCoordinates = coordinatesRectangle.Max();
            
            if(hasRectangle)
            {
                Console.WriteLine("\nНайдём прямоугольник, являющейся общей частью (пересечением) двух прямоугольников..." +
               "\nЕго координаты:\n  x1 |  y1 |  x2 | y2 \n=========================");
                Console.WriteLine("  " + minNewCoordinates.Item2 + "  |  " + minNewCoordinates.Item3 + "  |  " +
                    maxNewCoordinates.Item2 + "  |  " + maxNewCoordinates.Item3);
            }
            else
            {
                Console.WriteLine("Введённые параметры не корректны или такого прямоугольника не существует ");
            }
        }

        //Метод на проверку нового прямоугольника созданного пересечением
        private bool HasCrossRectangle(Tuple<double, int, int> minCoordinatesRectangle1, Tuple<double, int, int> maxCoordinatesRectangle1,
            Tuple<double, int, int> minCoordinatesRectangle2, Tuple<double, int, int> maxCoordinatesRectangle2)
        {
            if (minCoordinatesRectangle1.Item1 > minCoordinatesRectangle2.Item1 && maxCoordinatesRectangle1.Item1 > minCoordinatesRectangle2.Item1)
                return true;
            if (minCoordinatesRectangle2.Item1 > minCoordinatesRectangle1.Item1 && maxCoordinatesRectangle2.Item1 > minCoordinatesRectangle1.Item1)
                return true;
            return false;
        }

        //Проверят что существует прямоугольник ( проверят сраз 2 )
        private bool HasRectangle(Tuple<double, int, int> minCoordinatesRectangle1, Tuple<double, int, int> maxCoordinatesRectangle1,
            Tuple<double, int, int> minCoordinatesRectangle2, Tuple<double, int, int> maxCoordinatesRectangle2)
        {
            if (minCoordinatesRectangle1.Item2 > maxCoordinatesRectangle1.Item2)
                return false;
            if (minCoordinatesRectangle1.Item3 > maxCoordinatesRectangle1.Item3)
                return false;
            if (minCoordinatesRectangle2.Item2 > maxCoordinatesRectangle2.Item2)
                return false;
            if (minCoordinatesRectangle2.Item3 > maxCoordinatesRectangle2.Item3)
                return false;
            return true;
        }
    }
}
