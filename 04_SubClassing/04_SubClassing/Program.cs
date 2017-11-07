using System;
using Gtk;


class MainClass
{

	public static void Main(string[] args)
	{
		Application.Init();

		Window w = new Window("Hit Count");
		MyButton b = new MyButton("Hit Count");
		b.Clicked += Button_Clicked;

		w.DeleteEvent += Delete_Event;
		w.Add(b);
		w.ShowAll();
		Application.Run();
	}

	public static void Button_Clicked(object sender, EventArgs o)
	{
		MyButton b = (MyButton)sender;
		Console.WriteLine("Clicked {0} times", b.HitCount);
	}

	public static void Delete_Event(object sender, DeleteEventArgs e)
	{
		Application.Quit();
		e.RetVal = true;
	}
}

class MyButton : Button
{

	private int hitcount;

	public MyButton(string text) : base(text)
	{
		hitcount = 0;
	}

	protected override void OnClicked()
	{
		hitcount++;
		base.OnClicked();
	}

	public int HitCount
	{
		get { return hitcount; }
		set { hitcount = value; }
	}

}