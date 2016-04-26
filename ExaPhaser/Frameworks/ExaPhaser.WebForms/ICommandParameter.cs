using System;
namespace ExaPhaser.WebForms
{
	public class ICommandParameter
	{
		public object Parameter { get; private set; }
		public ICommandParameter()
		{
		}

		public ICommandParameter(EventArgs e)
		{
			Parameter = e;
		}
	}
}

