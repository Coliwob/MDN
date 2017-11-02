using System;
using Gtk;

namespace layout
{

	public class Layout
	{
		public static void Main(string[] args)
		{
			Application.Init();
			SetUpGui();
			Application.Run();
		}

		private static void SetUpGui()
		{
			Window mainWindow = new Window("Layout");

			HBox hBox = new HBox();
			hBox.BorderWidth = 6;
			hBox.Spacing = 6;
			mainWindow.Add(hBox);

			VBox vBox = new VBox();
			vBox.Spacing = 6;
			hBox.PackStart(vBox, false, false, 0);

			Label label = new Label("Full Name");
			label.Xalign = 0;
			vBox.PackStart(label, true, false, 0);

			label = new Label("Email Address");
			label.Xalign = 0;
			vBox.PackStart(label, true, false, 0);

			vBox = new VBox();
			vBox.Spacing = 6;
			hBox.PackStart(vBox, true, false, 0);

			vBox.PackStart(new Entry(), true, true, 0);
			vBox.PackStart(new Entry(), true, true, 0);

			mainWindow.DeleteEvent += Window_Delete;
			mainWindow.ShowAll();
		}

		private static void Window_Delete(object sender, DeleteEventArgs e)
		{
			Application.Quit();
			e.RetVal = true;
		}
	
	}


}