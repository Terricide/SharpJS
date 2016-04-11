using System;
using System.IO;
using JSIL.Meta;

namespace System.Xml.Serialization
{
	
	[JSStubOnly]
	public class XmlSerializer
	{
		
		protected XmlSerializer()
		{
			throw new NotImplementedException();
		}

		
		public XmlSerializer(Type type)
		{
			throw new NotImplementedException();
		}

		
		public virtual bool CanDeserialize(XmlReader xmlReader)
		{
			throw new NotImplementedException();
		}

		
		protected virtual XmlSerializationReader CreateReader()
		{
			throw new NotImplementedException();
		}

		
		protected virtual XmlSerializationWriter CreateWriter()
		{
			throw new NotImplementedException();
		}

		
		public object Deserialize(Stream stream)
		{
			throw new NotImplementedException();
		}

		
		public object Deserialize(XmlReader xmlReader)
		{
			throw new NotImplementedException();
		}

		
		protected virtual object Deserialize(XmlSerializationReader reader)
		{
			throw new NotImplementedException();
		}

		
		public void Serialize(Stream stream, object o)
		{
			throw new NotImplementedException();
		}

		
		protected virtual void Serialize(object o, XmlSerializationWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}
