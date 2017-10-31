using System;

namespace beverage
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			Drink[] drinks = new Drink[2];
			Drink jolt = new Drink("Jolt", new BeverageSize(12, Units.Ounces), 0.25);
			Drink coke = new Drink("Coke", new BeverageSize(12, Units.Ounces), 0.125);

			drinks[0] = jolt;
			drinks[1] = coke;

			foreach (Drink drink in drinks)
			{
				Console.WriteLine(drink.ToString());
			}

			Console.ReadLine();
		}
	}


	public class Drink : IDrink
	{
		private string brand;
		private BeverageSize volume;
		private double percentCaffine;

		public Drink(string brand, BeverageSize volume, double percentCaffine)
		{
			this.brand = brand;
			this.volume = volume;
			this.percentCaffine = percentCaffine;
		}

		public string Brand
		{
			get { return brand; }
		}

		public BeverageSize Volume
		{
			get { return volume; }
		}

		public double PercentCaffine
		{
			get { return percentCaffine; }
		}

		public override string ToString()
		{
			return Volume + " " + Brand + " drink, with " + PercentCaffine + "% caffine.";
		}
	}

	public interface IDrink
	{
		string Brand { get; }
		BeverageSize Volume { get; }
		double PercentCaffine { get; }
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
		}	}

}