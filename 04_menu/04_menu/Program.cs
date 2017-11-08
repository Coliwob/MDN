using System;
using Gtk;
namespace _menu
{
	public class Program
	{
		private static Gtk.Window w;

		public static void Main(string[] args)
		{
			Application.Init();

			w = new Gtk.Window("Menu Example");
			w.DeleteEvent += Delete_Event;
			w.SetDefaultSize(260, 150);

			MenuBar mb = new MenuBar();

			AccelGroup agrp = new AccelGroup();
			w.AddAccelGroup(agrp);

			//File Menu
			Menu menu_file = new Menu();
			MenuItem item = new MenuItem("_File");
			item.Submenu = menu_file;
			mb.Append(item);

			//Open
			item = new ImageMenuItem(Stock.Open, agrp);
			item.Activated += Action_Open;
			menu_file.Append(item);

			//Close
			item = new ImageMenuItem(Stock.Close, agrp);
			menu_file.Append(item);

			//Seperator
			menu_file.Append(new SeparatorMenuItem());

			//Quit
			item = new ImageMenuItem(Stock.Quit, agrp);
			item.Activated += Action_Close;
			menu_file.Append(item);


			//Edit Menu
			Menu menu_edit = new Menu();
			item = new MenuItem("_Edit");
			item.Submenu = menu_edit;
			mb.Append(item);

			item = new MenuItem("_Transform");
			Menu menu_transform = new Menu();
			item.Submenu = menu_transform;
			menu_edit.Append(item);

			item = new MenuItem("_Rotate");

			//custom Accelerator
			item.AddAccelerator("activate", agrp, new AccelKey(Gdk.Key.R, Gdk.ModifierType.ControlMask, AccelFlags.Visible));

			item.Activated += Rotate_Activated;

			menu_transform.Append(item);
			item = new MenuItem("_Flip");
			menu_transform.Append(item);




			VBox v = new VBox();
			v.PackStart(mb, false, false, 0);
			w.Add(v);
			w.ShowAll();

			Application.Run();
		}


		public static void Delete_Event(object sender, DeleteEventArgs e)
		{
			Application.Quit();
		}

		public static void Action_Open(object sender, EventArgs e)
		{
			Console.WriteLine("Open");
		}

		public static void Action_Close(object sender, EventArgs e)
		{
			Delete_Event(sender, (DeleteEventArgs)e);		}

		public static void Rotate_Activated(object sender, EventArgs e)
		{
			Console.WriteLine("Rotate");
		}
	}


}
