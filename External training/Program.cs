using System;

namespace External_training
{
    public class Program
    {
        public static double Average(params int[] variable)
        {
            int summ = 0;
            foreach(var index in variable)
            {
                summ += index;
            }
            return summ / variable.Length;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Average(1,2,3,4));
            Console.ReadKey();
        }
    }
}
