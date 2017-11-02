using System;
using Gtk;
namespace test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Window w = new Window("TEST");
			Button b = new Button("Hit me!");

			w.DeleteEvent += new DeleteEventHandler(Window_Delete);
			b.Clicked += new EventHandler(Button_Clicked);

			w.Add(b);
			w.SetDefaultSize(200, 100);
			w.ShowAll();

			Application.Run();
		}

		private static void Window_Delete(object sender, DeleteEventArgs e)
		{
			Application.Quit();
			e.RetVal = true;
		}

		private static void Button_Clicked(object sender, EventArgs e)
		{
			System.Console.WriteLine("Button clicked");
		}
	}
}
