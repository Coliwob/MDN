using System;
using System.IO;

namespace FileFinder
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string filename = null;
			try
			{
				filename = args[0];

				using (StreamReader reader = File.OpenText(filename))
				{
					string contents = reader.ReadToEnd();
				}
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.Error.WriteLine("No filename specified");
				Environment.Exit(1);
			}
			catch (FileNotFoundException ex)
			{
				Console.Error.WriteLine("File \"{0}\" doen not exist.", filename);
				Environment.Exit(2);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				Environment.Exit(3);
			}
			finally
			{
				Console.WriteLine("Done");
			}
		}
	}
}
