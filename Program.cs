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
            Rectangle rectangle = new Rectangle();
            rectangle.MinimalRectangle(1, 3, 5, 4, 4, 1, 4, 1);
            rectangle.CrossRectangle(1, 1, 5, 5, 10, 10, 15, 15);

            Rectangle rectangle2 = new Rectangle(0, 0, 10, 5);
            rectangle2.SetNewPosition(10, 1);
            rectangle2.SetNewSize(9, 2);
            Console.ReadKey();
        }
    }
}
