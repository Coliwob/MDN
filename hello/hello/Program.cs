using System;

namespace hello
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.Error.WriteLine("Enter your name!");
				Environment.Exit(-1);
			}

			string name = args[0];
			Console.WriteLine("Hello, {0}!", name);

			if (args.Length > 1)
			{
				foreach (string arg in args)
				{
					Console.WriteLine(arg);
				}
			}
		}
	}
}
