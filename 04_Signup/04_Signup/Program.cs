using System;
using Gtk;

public class MainClass
{
	static Entry entry_firstName, entry_lastName, entry_email;

	public static void Main(string[] args)
	{
		Application.Init();
		SetUpGui();
		Application.Run();
	}


	private static void SetUpGui()
	{
		Window w = new Window("Sign Up");
		w.SetDefaultSize(450, 350);
		entry_firstName = new Entry();
		entry_lastName = new Entry();
		entry_email = new Entry();

		VBox outerv = new VBox();
		outerv.BorderWidth = 12;
		outerv.Spacing = 12;
		w.Add(outerv);

		Label l = new Label("<span weight=\"bold\" size =\"larger\">" + "Enter your name and prefered address </span>");
		l.Xalign = 0;
		l.UseMarkup = true;
		outerv.PackStart(l, false, false, 0);

		HBox h = new HBox();
		h.Spacing = 6;
		outerv.Add(h);

		VBox v = new VBox();
		v.Spacing = 6;
		h.PackStart(v, false, false, 0);

		l = new Label("_First name");
		l.Xalign = 0;
		v.PackStart(l, true, false, 0);
		l.MnemonicWidget = entry_firstName;

		l = new Label("_Last name");
		l.Xalign = 0;
		v.PackStart(l, true, false, 0);
		l.MnemonicWidget = entry_lastName;

		l = new Label("_Email Address");
		l.Xalign = 0;
		v.PackStart(l, true, false, 0);
		l.MnemonicWidget = entry_email;

		v = new VBox();
		v.Spacing = 6;
		h.PackStart(v, false, false, 0);

		v.PackStart(entry_firstName, true, true, 0);
		v.PackStart(entry_lastName, true, true, 0);
		v.PackStart(entry_email, true, true, 0);

		entry_firstName.Changed += Name_Changed;
		entry_lastName.Changed += Name_Changed;
		w.DeleteEvent += Window_Delete;
		w.ShowAll();
	}


	private static void Window_Delete(object sender, DeleteEventArgs e)
	{
		Application.Quit();
		e.RetVal = true;
	}

	private static void Name_Changed(object sender, EventArgs e)
	{
		string newEmail = entry_firstName.Text.ToLower() + "." + entry_lastName.Text.ToLower() + "@examplemail.net";
		entry_email.Text = newEmail;
	}
}