using System;

namespace beverage
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			Drink[] drinks = new Drink[2];
			Drink jolt = new Drink("Jolt", 12.0, 0.25);
			Drink coke = new Drink("Coke", 12.0, 0.125);

			drinks[0] = jolt;
			drinks[1] = coke;

			foreach (Drink drink in drinks)
			{
				Console.WriteLine(drink.ToString());
			}

			Console.ReadLine();
		}
	}

	public class Drink 
	{
		private string brand;
		private double volume;
		private double percentCaffine;

		public Drink(string brand, double volume, double percentCaffine)
		{
			this.brand = brand;
			this.volume = volume;
			this.percentCaffine = percentCaffine;
		}

		public string Brand
		{
			get { return brand; }
		}

		public double Volume
		{
			get { return volume; }
		}

		public double PercentCaffine
		{
			get { return percentCaffine; }
		}

		public override string ToString()
		{
			return Volume + "oz " + Brand + " drink, with " + PercentCaffine + "% caffine.";
		}
	}

}
