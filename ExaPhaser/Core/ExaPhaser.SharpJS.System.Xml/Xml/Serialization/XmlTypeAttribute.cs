using System;

namespace System.Xml.Serialization
{
	
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	public class XmlTypeAttribute : Attribute
	{
		
		public XmlTypeAttribute()
		{
		}

		
		public XmlTypeAttribute(string typeName)
		{
			this.typeName = typeName;
		}

		
		public bool AnonymousType
		{
			
			get
			{
				return this.anonymousType;
			}
			
			set
			{
				this.anonymousType = value;
			}
		}

		
		public bool IncludeInSchema
		{
			
			get
			{
				return this.includeInSchema;
			}
			
			set
			{
				this.includeInSchema = value;
			}
		}

		
		public string Namespace
		{
			
			get
			{
				return this.ns;
			}
			
			set
			{
				this.ns = value;
			}
		}

		
		public string TypeName
		{
			
			get
			{
				return (this.typeName == null) ? string.Empty : this.typeName;
			}
			
			set
			{
				this.typeName = value;
			}
		}

		
		private bool anonymousType;

		
		private bool includeInSchema = true;

		
		private string ns;

		
		private string typeName;
	}
}
