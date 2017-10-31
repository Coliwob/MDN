using System;

namespace ValueTypes
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			BeverageSize size = new BeverageSize(12.0, Units.Ounces);
			Console.WriteLine(size);
			Console.ReadLine();
		}
	}

	public enum Units { Ounces, Liters, Pints }
	public struct BeverageSize
	{
		private double volume;
		private Units units;

		public BeverageSize(double volume, Units units)
		{
			this.volume = volume;
			this.units = units;
		}

		public override string ToString()
		{
			return volume + " " + units;
		}
	}
}
