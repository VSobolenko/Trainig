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
            Rectangle rectangle = new Rectangle();
            rectangle.MinimalRectangle(1, 3, 5, 4, 4, 1, 4, 1);
            Console.ReadKey();
        }
    }
}
