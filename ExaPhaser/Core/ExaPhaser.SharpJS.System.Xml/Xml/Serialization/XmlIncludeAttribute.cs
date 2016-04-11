using System;

namespace System.Xml.Serialization
{
	
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface, AllowMultiple = true)]
	public class XmlIncludeAttribute : Attribute
	{
		
		public XmlIncludeAttribute(Type type)
		{
			this.type = type;
		}

		
		public Type Type
		{
			
			get
			{
				return this.type;
			}
			
			set
			{
				this.type = value;
			}
		}

		
		private Type type;
	}
}
