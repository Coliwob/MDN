using System;
using Gtk;
using _Dialog;

public class MainClass
{
	public static void Main(string[] args)
	{
		Application.Init();

		MyDialog d = new MyDialog("Catering Request", "Would you like fries with that?", "Beware though, they taste boggin.");

		ResponseType resp = (ResponseType)d.Run();

		if (resp == ResponseType.Ok)
		{
			Console.WriteLine("You got fat");
		}
		else if (resp == ResponseType.Cancel)
		{
			Console.WriteLine("You didnt got fat");
		}


	}
}
