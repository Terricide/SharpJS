using JSIL.Meta;

namespace System.Xml.Serialization
{
    [JSStubOnly]
    public abstract class XmlSerializationReader : XmlSerializationGeneratedCode
    {
        protected XmlSerializationReader()
        {
            throw new NotImplementedException();
        }

        protected void CheckReaderCount(ref int whileIterations, ref int readerCount)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateAbstractTypeException(string name, string ns)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateBadDerivationException(string xsdDerived, string nsDerived, string xsdBase, string nsBase, string clrDerived, string clrBase)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateCtorHasSecurityException(string typeName)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateInaccessibleConstructorException(string typeName)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateInvalidCastException(Type type, object value)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateInvalidCastException(Type type, object value, string id)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateMissingIXmlSerializableType(string name, string ns, string clrType)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateReadOnlyCollectionException(string name)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateUnknownConstantException(string value, Type enumType)
        {
            throw new NotImplementedException();
        }

        protected Exception CreateUnknownNodeException()
        {
            throw new NotImplementedException();
        }

        protected Exception CreateUnknownTypeException(XmlQualifiedName type)
        {
            throw new NotImplementedException();
        }

        protected Array EnsureArrayIndex(Array a, int index, Type elementType)
        {
            throw new NotImplementedException();
        }

        protected bool GetNullAttr()
        {
            throw new NotImplementedException();
        }

        protected XmlQualifiedName GetXsiType()
        {
            throw new NotImplementedException();
        }

        protected abstract void InitCallbacks();

        protected abstract void InitIDs();

        protected bool IsXmlnsAttribute(string name)
        {
            throw new NotImplementedException();
        }

        protected void ReadEndElement()
        {
            throw new NotImplementedException();
        }

        protected bool ReadNull()
        {
            throw new NotImplementedException();
        }

        protected IXmlSerializable ReadSerializable(IXmlSerializable serializable)
        {
            throw new NotImplementedException();
        }

        protected IXmlSerializable ReadSerializable(IXmlSerializable serializable, bool wrappedAny)
        {
            throw new NotImplementedException();
        }

        protected string ReadString(string value)
        {
            throw new NotImplementedException();
        }

        protected string ReadString(string value, bool trim)
        {
            throw new NotImplementedException();
        }

        protected Array ShrinkArray(Array a, int length, Type elementType, bool isNullable)
        {
            return null;
        }

        protected byte[] ToByteArrayBase64(bool isNull)
        {
            byte[] result;
            if (isNull)
            {
                result = null;
            }
            else
            {
                result = null;
            }
            return result;
        }

        protected static byte[] ToByteArrayBase64(string value)
        {
            byte[] result;
            if (value == null)
            {
                result = null;
            }
            else
            {
                value = value.Trim();
                if (value.Length == 0)
                {
                    result = new byte[0];
                }
                else
                {
                    result = Convert.FromBase64String(value);
                }
            }
            return result;
        }

        protected static char ToChar(string value)
        {
            throw new NotImplementedException();
        }

        protected static DateTime ToDateTime(string value)
        {
            throw new NotImplementedException();
        }

        protected void UnknownNode(object o)
        {
            throw new NotImplementedException();
        }

        protected void UnknownNode(object o, string qnames)
        {
            throw new NotImplementedException();
        }

        protected XmlReader Reader
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected int ReaderCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}