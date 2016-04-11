using System;

namespace System.Xml.Serialization
{
	
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.ReturnValue)]
	public class XmlRootAttribute : Attribute
	{
		
		public XmlRootAttribute()
		{
		}

		
		public XmlRootAttribute(string elementName)
		{
			this.elementName = elementName;
		}

		
		public string DataType
		{
			
			get
			{
				return (this.dataType == null) ? string.Empty : this.dataType;
			}
			
			set
			{
				this.dataType = value;
			}
		}

		
		public string ElementName
		{
			
			get
			{
				return (this.elementName == null) ? string.Empty : this.elementName;
			}
			
			set
			{
				this.elementName = value;
			}
		}

		
		public bool IsNullable
		{
			
			get
			{
				return this.nullable;
			}
			
			set
			{
				this.nullable = value;
				this.nullableSpecified = true;
			}
		}

		
		internal bool IsNullableSpecified
		{
			
			get
			{
				return this.nullableSpecified;
			}
		}

		
		internal string Key
		{
			
			get
			{
				return string.Concat(new string[]
				{
					(this.ns == null) ? string.Empty : this.ns,
					":",
					this.ElementName,
					":",
					this.nullable.ToString()
				});
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

		
		private string dataType;

		
		private string elementName;

		
		private string ns;

		
		private bool nullable = true;

		
		private bool nullableSpecified;
	}
}
