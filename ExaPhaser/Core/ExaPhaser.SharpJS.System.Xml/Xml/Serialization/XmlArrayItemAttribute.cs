using System;
using System.Xml.Schema;

namespace System.Xml.Serialization
{
	
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
	public class XmlArrayItemAttribute : Attribute
	{
		
		public XmlArrayItemAttribute()
		{
		}

		
		public XmlArrayItemAttribute(string elementName)
		{
			this.elementName = elementName;
		}

		
		public XmlArrayItemAttribute(Type type)
		{
			this.type = type;
		}

		
		public XmlArrayItemAttribute(string elementName, Type type)
		{
			this.elementName = elementName;
			this.type = type;
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

		
		public XmlSchemaForm Form
		{
			
			get
			{
				return this.form;
			}
			
			set
			{
				this.form = value;
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

		
		public int NestingLevel
		{
			
			get
			{
				return this.nestingLevel;
			}
			
			set
			{
				this.nestingLevel = value;
			}
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

		
		private string dataType;

		
		private string elementName;

		
		private XmlSchemaForm form = XmlSchemaForm.None;

		
		private int nestingLevel;

		
		private string ns;

		
		private bool nullable;

		
		private bool nullableSpecified = false;

		
		private Type type;
	}
}
