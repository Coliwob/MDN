using System;



namespace MethodAttributeImplementation
{
	public class MainClass
	{
		public static void Main(string[] args)
		{

		}

		[MethodAttribute(0, NamedParam = "foo")]
		public void MyMethod()
		{
		}


	}







}