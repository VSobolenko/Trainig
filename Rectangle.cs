using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_training
{
    class Rectangle
    {
        private int _x, _y;
        private int _width, _height; //Длина - по Ox, ширина - по Oy
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
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                if (value > 0)
                    _height = value;
            }
        }
        public void SetNewPosition(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public void SetNewSize(int width, int heifht)
        {
            _width = width;
            _height = heifht;
        }
        public void MinimalRectangle(int x1, int y1, int x2, int y2, int width1, int height1, int width2, int height2)
        {
            /*
                Item1 - длина от точки (0,0), до точки (x,y) 
                Item2 - координата x
                Item3 - координата y
             */

            List<Tuple<double, int, int>> vertices = new List<Tuple<double, int, int>>
            {
                Tuple.Create(Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)), x1, y1),
                Tuple.Create(Math.Sqrt(Math.Pow(x1 + width1, 2) + Math.Pow(y1 + height1, 2)), x1 + width1, y1 + height1),

                Tuple.Create(Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)), x2, y2),
                Tuple.Create(Math.Sqrt(Math.Pow(x2 + width2, 2) + Math.Pow(y1 + height2, 2)), x2 + width2, y1 + height2)
            };

            var minCoordinates = vertices.Min();
            var maxCoordinates = vertices.Max();

            Console.WriteLine("Таблица координатов:\n diagonal |   x  |    y  ");
            Console.WriteLine("=========================");
            foreach(var index in vertices)
            {
                Console.WriteLine("{0,9:F5} | {1,4} | {2,4}",index.Item1, index.Item2, index.Item3);
            }

            Console.WriteLine("\nНайдём минимальный прямоугольник, содержащий 2 заданных прямоугольника..." + "\nЕго координаты:\n  x1 |  y1 |  x2 | y2 \n=========================");
            Console.WriteLine("  " + minCoordinates.Item2 + "  |  " + minCoordinates.Item3 + "  |  " +
                maxCoordinates.Item2 + "  |  " + maxCoordinates.Item3);
        }
        public void CrossRectangle(int x1, int y1, int x2, int y2, int width1, int height1, int width2, int height2)
        {
        }
    }
}
