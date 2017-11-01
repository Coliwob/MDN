using System;
using System.Runtime.InteropServices;

namespace PInvoke
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Curses Curses = new Curses();
			Curses.Print(10, 10, "Hello");
			Curses.Refresh();
			char c = Curses.GetChar();
			Curses = null;
		}
	}

	public class Curses
	{
		const string Library = "ncurses";

		[DllImport(Library)]
		private extern static IntPtr initscr();

		[DllImport(Library)]
		private extern static int endwin();

		[DllImport(Library)]
		private extern static int mvwprintw(IntPtr window, int y, int x, string message);

		[DllImport(Library)]
		private extern static int refresh(IntPtr window);

		[DllImport(Library)]
		private extern static int wgetch(IntPtr window);

		private IntPtr window;

		public Curses()
		{
			window = initscr();
		}

		public int Print(int x, int y, string message)
		{
			return mvwprintw(window, y, x, message);
		}

		public int Refresh()
		{
			return refresh(window);
		}

		public char GetChar()
		{
			return (char)wgetch(window);
		}
	}


}
