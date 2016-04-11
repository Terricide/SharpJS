using System;

namespace System.ComponentModel
{
	
	[AttributeUsage(AttributeTargets.All)]
	public class DefaultValueAttribute : Attribute
	{
		
		public DefaultValueAttribute(char value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(byte value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(short value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(int value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(long value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(float value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(double value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(bool value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(string value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(object value)
		{
			this.value = value;
		}

		
		public DefaultValueAttribute(Type type, string value)
		{
		}

		
		public override bool Equals(object obj)
		{
			bool result;
			if (obj == this)
			{
				result = true;
			}
			else
			{
				DefaultValueAttribute defaultValueAttribute = obj as DefaultValueAttribute;
				if (defaultValueAttribute != null)
				{
					if (this.Value != null)
					{
						result = this.Value.Equals(defaultValueAttribute.Value);
					}
					else
					{
						result = (defaultValueAttribute.Value == null);
					}
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		
		protected void SetValue(object value)
		{
			this.value = value;
		}

		
		public virtual object Value
		{
			
			get
			{
				return this.value;
			}
		}

		
		private object value;
	}
}
