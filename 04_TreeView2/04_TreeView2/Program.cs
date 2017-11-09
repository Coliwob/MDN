using System;
using Gtk;

public class Program
{
	public static void Main(string[] args)
	{
		Application.Init();
		Window w = new Window("TreeView - Tree Shaped Data");
		w.DeleteEvent += Window_Delete;
		VBox v = new VBox();
		v.BorderWidth = 16;
		w.Add(v);

		TreeView tv = new TreeView();
		tv.HeadersVisible = true;
		v.Add(tv);

		TreeViewColumn col = new TreeViewColumn();
		CellRenderer colr = new CellRendererText();
		col.Title = "Column 1";
		col.PackStart(colr, true);
		col.AddAttribute(colr, "text", 0);
		tv.AppendColumn(col);

		TreeStore store = new TreeStore(typeof(string));
		tv.Model = store;

		TreeIter iter = new TreeIter();
		for (int i = 0; i < 4; i++)
		{
			iter = store.AppendValues("Point " + i.ToString());
			for (int j = i - 1; j >= 0; j--)
			{
				iter = store.AppendValues(iter, "Visited " + j.ToString());
				iter = store.AppendValues(iter, "Visited " + j.ToString());
				iter = store.AppendValues(iter, "Visited " + j.ToString());
				iter = store.AppendValues(iter, "Visited " + j.ToString());
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