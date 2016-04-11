using System;
using System.Text;

namespace System.Xml.Serialization
{
	
	public abstract class XmlSerializationWriter : XmlSerializationGeneratedCode
	{
		
		protected Exception CreateInvalidEnumValueException(object value, string typeName)
		{
			return new InvalidOperationException(string.Concat(new object[]
			{
				"Invalid enum value '",
				value,
				"' for type '",
				typeName,
				"'."
			}));
		}

		
		protected Exception CreateUnknownTypeException(object o)
		{
			return this.CreateUnknownTypeException(o.GetType());
		}

		
		protected Exception CreateUnknownTypeException(Type type)
		{
			return new InvalidOperationException("Unknown type for serialization: " + type.FullName);
		}

		
		protected static byte[] FromByteArrayBase64(byte[] value)
		{
			return value;
		}

		
		protected static string FromChar(char value)
		{
			return string.Concat(value);
		}

		
		protected static string FromDateTime(DateTime value)
		{
			TimeSpan t = value - value.Date;
			t -= new TimeSpan(value.Hour, value.Minute, value.Second);
			string text = (t.Ticks > 1000000L) ? t.Ticks.ToString() : ("0" + t.Ticks);
			if (text.EndsWith("0000"))
			{
				text = text.Substring(0, text.Length - 4);
			}
			string text2 = string.Concat(value.Second);
			if (text2.Length == 1)
			{
				text2 = 0 + text2;
			}
			string text3 = string.Concat(value.Minute);
			if (text3.Length == 1)
			{
				text3 = 0 + text3;
			}
			string text4 = string.Concat(value.Hour);
			if (text4.Length == 1)
			{
				text4 = 0 + text4;
			}
			string text5 = string.Concat(value.Day);
			if (text5.Length == 1)
			{
				text5 = 0 + text5;
			}
			string text6 = string.Concat(value.Month);
			if (text6.Length == 1)
			{
				text6 = 0 + text6;
			}
			string text7 = string.Concat(value.Year);
			while (text7.Length < 4)
			{
				text7 = 0 + text7;
			}
			string text8 = string.Concat(new string[]
			{
				text7,
				"-",
				text6,
				"-",
				text5,
				"T",
				text4,
				":",
				text3,
				":",
				text2
			});
			if (t.Ticks != 0L)
			{
				text8 = text8 + "." + text;
			}
			if (value.Kind == DateTimeKind.Local)
			{
				TimeSpan timeSpan = value - value.ToUniversalTime();
				string text9 = string.Concat(timeSpan.Minutes);
				if (text9.Length == 1)
				{
					text9 = 0 + text9;
				}
				string text10 = string.Concat(timeSpan.Hours);
				if (text10.Length == 1)
				{
					text10 = 0 + text10;
				}
				string str = text10 + ":" + text9;
				if (timeSpan.Ticks >= 0L)
				{
					str = "+" + str;
				}
				text8 += str;
			}
			else if (value.Kind == DateTimeKind.Utc)
			{
				text8 += "Z";
			}
			return text8;
		}

		
		private void Init(XmlWriter xmlWriter, XmlSerializerNamespaces namespaces, string encodingStyle, string id)
		{
			this._xmlWriter = xmlWriter;
		}

		
		protected abstract void InitCallbacks();

		
		protected void TopLevelElement()
		{
		}

		
		protected void WriteElementString(string localName, string ns, string value)
		{
			this._xmlWriter.WriteStartElement(localName);
			if (value != null)
			{
				this._xmlWriter.WriteString(InternalEscapeHelpers.EscapeXml(value));
			}
			this._xmlWriter.WriteEndElement();
		}

		
		protected void WriteElementStringRaw(string localName, string ns, string value)
		{
			this._xmlWriter.WriteStartElement(localName);
			this._xmlWriter.WriteString(InternalEscapeHelpers.EscapeXml(value));
			this._xmlWriter.WriteEndElement();
		}

		
		protected void WriteElementStringRaw(string localName, string ns, byte[] value)
		{
			this._xmlWriter.WriteStartElement(localName);
			this._xmlWriter.WriteString(InternalEscapeHelpers.EscapeXml(Encoding.UTF8.GetString(value)));
			this._xmlWriter.WriteEndElement();
		}

		
		protected void WriteEmptyTag(string name, string ns)
		{
		}

		
		protected void WriteEndElement()
		{
			this._xmlWriter.WriteEndElement();
		}

		
		protected void WriteEndElement(object o)
		{
			this.WriteEndElement();
		}

		
		protected void WriteNullableStringLiteral(string name, string ns, string value)
		{
			this._xmlWriter.WriteStartElement(name);
			if (value != null)
			{
				this._xmlWriter.WriteString(value);
			}
			this._xmlWriter.WriteEndElement();
		}

		
		protected void WriteNullableStringLiteralRaw(string name, string ns, string value)
		{
		}

		
		protected void WriteNullTagLiteral(string name, string ns)
		{
			if (name != null && name.Length != 0)
			{
				this.WriteStartElement(name, ns, null, false, null);
				this._xmlWriter.WriteAttributeString("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
				this._xmlWriter.WriteAttributeString("i:nil", "true");
				this._xmlWriter.WriteEndElement();
			}
		}

		
		protected void WriteStartDocument()
		{
			this._xmlWriter.WriteStartDocument();
		}

		
		protected void WriteStartElement(string name, string ns, object o, bool writePrefixed)
		{
			this.WriteStartElement(name, ns, o, writePrefixed, null);
		}

		
		protected void WriteStartElement(string name, string ns, object o, bool writePrefixed, XmlSerializerNamespaces xmlns)
		{
			if (string.IsNullOrWhiteSpace(ns))
			{
				this._xmlWriter.WriteStartElement(name);
			}
			else
			{
				this._xmlWriter.WriteStartElement(name, ns);
			}
		}

		
		protected void WriteXsiType(string name, string ns)
		{
			throw new NotImplementedException();
		}

		
		private XmlWriter _xmlWriter;
	}
}
