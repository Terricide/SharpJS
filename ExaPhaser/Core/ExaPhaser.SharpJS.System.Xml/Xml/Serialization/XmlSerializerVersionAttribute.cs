using System;

namespace System.Xml.Serialization
{
	
	[AttributeUsage(AttributeTargets.Assembly)]
	public sealed class XmlSerializerVersionAttribute : Attribute
	{
		
		public XmlSerializerVersionAttribute()
		{
		}

		
		public XmlSerializerVersionAttribute(Type type)
		{
		}

		
		public string Namespace
		{
			
			get;
			
			set;
		}

		
		public string ParentAssemblyId
		{
			
			get;
			
			set;
		}

		
		public Type Type
		{
			
			get;
			
			set;
		}

		
		public string Version
		{
			
			get;
			
			set;
		}
	}
}
