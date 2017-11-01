using System;


	[AttributeUsage(AttributeTargets.Method)]
	public class MethodAttribute : Attribute
	{
		private string namedParam;
		private int positionParam;

		public string NamedParam
		{
			get { return namedParam; }
			set { namedParam = value; }
		}

		public MethodAttribute(int positionParam)
		{
			this.positionParam = positionParam;
		}
	}

