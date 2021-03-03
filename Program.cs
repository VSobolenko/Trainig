using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_training
{
    class Program
    {
		public static void Main()
		{
			WriteFor();

			WriteForeach();
		}

		private static void WriteFor()
		{
			var funcs = new List<Func<int>>();

			for (int i = 0; i < 3; i++)
			{
				funcs.Add(() => i);
			}

			foreach (var f in funcs)
				Console.WriteLine(f());
		}

		private static void WriteForeach()
		{
			var funcs = new List<Func<int>>();

			foreach (var i in Enumerable.Range(1, 3))
			{
				funcs.Add(() => i);
			}

			foreach (var f in funcs)
				Console.WriteLine(f());
		}
	}
}
