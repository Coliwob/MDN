using System;
using System.IO;

namespace WatchDirectory
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			string path = (string)args[0];
			FileSystemWatcher watcher = new FileSystemWatcher(path);
			watcher.Filter = "*";

			watcher.Changed += new FileSystemEventHandler(OnChanged);
			watcher.Created += new FileSystemEventHandler(OnCreated);
			watcher.Deleted += new FileSystemEventHandler(OnDeleted);
			watcher.Renamed += new RenamedEventHandler(OnRenamed);

			FileSystemEventHandler onFileSystemEvent = new FileSystemEventHandler(OnFileSystemEvent);
			watcher.Changed += onFileSystemEvent;
			watcher.Created += onFileSystemEvent;
			watcher.Deleted += onFileSystemEvent;

			watcher.EnableRaisingEvents = true;
			Console.WriteLine("Enable watcher on {0}; " + "hit return to terminate", path);

			Console.ReadLine();

			watcher.Changed -= new FileSystemEventHandler(OnChanged);
			watcher.Created -= new FileSystemEventHandler(OnCreated);
			watcher.Deleted -= new FileSystemEventHandler(OnDeleted);
			watcher.Renamed -= new RenamedEventHandler(OnRenamed);

			watcher.Changed -= onFileSystemEvent;
			watcher.Created -= onFileSystemEvent;
			watcher.Deleted -= onFileSystemEvent;

			Console.WriteLine("Done");
		}

		private static void OnFileSystemEvent(object sender, FileSystemEventArgs e)
		{
			Console.WriteLine("Something happened to {0}", e.Name);
		}

		private static void OnChanged(object sender, FileSystemEventArgs e)
		{
			Console.WriteLine("{0} changed", e.Name);
		}

		private static void OnCreated(object sender, FileSystemEventArgs e)
		{
			Console.WriteLine("{0} created", e.Name);
		}

		private static void OnDeleted(object sender, FileSystemEventArgs e)
		{
			Console.WriteLine("{0} deleted", e.Name);
		}

		private static void OnRenamed(object sender, RenamedEventArgs e)
		{
			Console.WriteLine("{0} renamed to {1}", e.OldName, e.Name);
		}



	}
}
