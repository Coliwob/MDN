using System;
using Gtk;
using Gdk;

class MainClass
{
	private static Gtk.Button add_png;
	private static Gtk.DrawingArea darea;
	private static Gdk.Pixmap pixmap;
	private static Gdk.Pixbuf pngbuf;
	private static Random rand;

	public static void Main(string[] args)
	{
		rand = new Random();
		Application.Init();

		pngbuf = new Pixbuf("B:/MDN/monkey.png");
		Gtk.Window w = new Gtk.Window("Graphics Demo");

		VBox v = new VBox();
		v.BorderWidth = 6;
		v.Spacing = 12;
		w.Add(v);

		darea = new DrawingArea();
		darea.SetSizeRequest(900, 700);
		darea.ExposeEvent += Expose_Event;
		darea.ConfigureEvent += Configure_Event;
		v.PackStart(darea);

		HBox h = new HBox();
		add_png = new Button("Add _Primate");
		add_png.Clicked += AddPng_Clicked;
		h.PackStart(add_png, false, false, 0);
		v.PackEnd(h, false, false, 0);

		w.ShowAll();
		w.Resizable = false;
		w.DeleteEvent += Window_Delete;

		Application.Run();
	}

	private static void PlacePixBuf(Gdk.Pixbuf buf)
	{
		Gdk.Rectangle allocation = darea.Allocation;
		int width = allocation.Width + 2 * buf.Width;
		int height = allocation.Height + 2 * buf.Height;
		int x = rand.Next(width) - buf.Width;
		int y = rand.Next(height) - buf.Height;
		pixmap.DrawPixbuf(darea.Style.BlackGC, buf, 0, 0, x, y, buf.Width, buf.Height, RgbDither.None, 0, 0);
		darea.QueueDrawArea(x, y, buf.Width, buf.Height);
	}

	private static void AddPng_Clicked(object sender, EventArgs e)
	{
		int scale = rand.Next(3) + 1;
		PlacePixBuf(pngbuf.ScaleSimple(pngbuf.Width / scale, pngbuf.Height / scale, InterpType.Hyper));
	}

	private static void Configure_Event(object sender, ConfigureEventArgs e)
	{
		Gdk.EventConfigure ev = e.Event;
		Gdk.Window window = ev.Window;
		Gdk.Rectangle allocation = darea.Allocation;
		pixmap = new Gdk.Pixmap(window, allocation.Width, allocation.Height, -1);
		pixmap.DrawRectangle(darea.Style.WhiteGC, true, 0, 0, allocation.Width, allocation.Height);
	}

	private static void Expose_Event(object sender, ExposeEventArgs e)
	{
		Gdk.Rectangle area = e.Event.Area;
		e.Event.Window.DrawDrawable(darea.Style.WhiteGC, pixmap, area.X, area.Y, area.X, area.Y, area.Width, area.Height);
	}

	private static void Window_Delete(object sender, DeleteEventArgs e)
	{
		Application.Quit();
		e.RetVal = true;
	}
}