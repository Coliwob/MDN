using System;
using Gtk;
namespace _Dialog
{
	public partial class MyDialog : Gtk.Dialog
	{
		public MyDialog(string title, string question, string explanation)
		{
			this.Title = title;
			this.HasSeparator = false;
			this.BorderWidth = 6;
			this.Resizable = false;

			HBox h = new HBox();
			h.BorderWidth = 6;
			h.Spacing = 12;

			Image i = new Image();
			i.SetFromStock(Stock.DialogQuestion, IconSize.Dialog);
			i.SetAlignment(0.5f, 0);
			h.PackStart(i, false, false, 0);

			VBox v = new VBox();
			Label l = new Label("<span weight=\"bold\" size=\"larger\">" + question + "</span>");
			l.LineWrap = true;
			l.UseMarkup = true;
			l.Selectable = true;
			l.Xalign = 0;
			l.Yalign = 0;
			v.PackStart(l);

			l = new Label(explanation);
			l.LineWrap = true;
			l.Selectable = true;
			l.Xalign = 0;
			l.Yalign = 0;
			v.PackEnd(l);

			h.PackEnd(v);
			h.ShowAll();
			this.VBox.Add(h);

			this.AddButton(Stock.Cancel, ResponseType.Cancel);
			this.AddButton(Stock.Ok, ResponseType.Ok);

		}
	}
}
