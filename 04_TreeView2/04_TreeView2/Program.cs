using System;
using Gtk;
using Gdk;
public class Program
{
	private static Pixbuf png;
	public static void Main(string[] args)
	{
		Application.Init();

		png = new Pixbuf("b:/mdn/16x16.png");

		Gtk.Window w = new Gtk.Window("TreeView - Tree Shaped Data");

		w.DeleteEvent += Window_Delete;
		VBox v = new VBox();
		v.BorderWidth = 16;
		w.Add(v);

		TreeView tv = new TreeView();
		tv.HeadersVisible = true;
		v.Add(tv);

		TreeViewColumn col = new TreeViewColumn();
		CellRendererPixbuf pixr = new CellRendererPixbuf();
		col.PackStart(pixr, false);
		col.AddAttribute(pixr, "pixbuf", 1);

		CellRenderer colr = new CellRendererText();
		col.Title = "Column 1";
		col.PackStart(colr, true);
		col.AddAttribute(colr, "text", 0);
		tv.AppendColumn(col);



		TreeStore store = new TreeStore(typeof(string), typeof(Pixbuf));
		tv.Model = store;

		TreeIter iter = new TreeIter();
		for (int i = 0; i < 4; i++)
		{
			iter = store.AppendValues("Point " + i.ToString(), png);
			for (int j = i - 1; j >= 0; j--)
			{
				store.AppendValues(iter, "Visited " + j.ToString(), png);
			}
		}

		w.ShowAll();
		Application.Run();

	}
	public static void Window_Delete(object sender, DeleteEventArgs e)
	{
		Application.Quit();
	}
}