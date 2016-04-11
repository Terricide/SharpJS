using System;

namespace System.Xml.Serialization
{
	
	[AttributeUsage(AttributeTargets.Field)]
	public class XmlEnumAttribute : Attribute
	{
		
		public XmlEnumAttribute()
		{
		}

		
		public XmlEnumAttribute(string name)
		{
			this.name = name;
		}

		
		public string Name
		{
			
			get
			{
				return this.name;
			}
			
			set
			{
				this.name = value;
			}
		}

		
		private string name;
	}
}
