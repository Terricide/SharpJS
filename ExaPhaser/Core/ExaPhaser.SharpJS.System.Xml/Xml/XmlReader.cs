using System.IO;
using JSIL.Meta;

namespace System.Xml
{
    [JSStubOnly]
    public abstract class XmlReader : IDisposable
    {
        protected XmlReader()
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(Stream input)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(string inputUri)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(TextReader input)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(Stream input, XmlReaderSettings settings)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(string inputUri, XmlReaderSettings settings)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(TextReader input, XmlReaderSettings settings)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(XmlReader reader, XmlReaderSettings settings)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(Stream input, XmlReaderSettings settings, string baseUri)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(Stream input, XmlReaderSettings settings, XmlParserContext inputContext)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(string inputUri, XmlReaderSettings settings, XmlParserContext inputContext)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(TextReader input, XmlReaderSettings settings, string baseUri)
        {
            throw new NotImplementedException();
        }

        public static XmlReader Create(TextReader input, XmlReaderSettings settings, XmlParserContext inputContext)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public abstract string GetAttribute(int i);

        public abstract string GetAttribute(string name);

        public abstract string GetAttribute(string name, string namespaceURI);

        public virtual bool IsStartElement()
        {
            throw new NotImplementedException();
        }

        public virtual bool IsStartElement(string name)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsStartElement(string localname, string ns)
        {
            throw new NotImplementedException();
        }

        public virtual XmlNodeType MoveToContent()
        {
            throw new NotImplementedException();
        }

        public abstract bool MoveToElement();

        public abstract bool MoveToFirstAttribute();

        public abstract bool MoveToNextAttribute();

        public abstract bool Read();

        public virtual string ReadContentAsString()
        {
            throw new NotImplementedException();
        }

        public virtual string ReadElementContentAsString()
        {
            throw new NotImplementedException();
        }

        public virtual string ReadElementContentAsString(string localName, string namespaceURI)
        {
            throw new NotImplementedException();
        }

        public virtual string ReadElementString()
        {
            throw new NotImplementedException();
        }

        public virtual string ReadElementString(string name)
        {
            throw new NotImplementedException();
        }

        public virtual string ReadElementString(string localname, string ns)
        {
            throw new NotImplementedException();
        }

        public virtual void ReadEndElement()
        {
            throw new NotImplementedException();
        }

        public virtual void ReadStartElement()
        {
            throw new NotImplementedException();
        }

        public virtual void ReadStartElement(string name)
        {
            throw new NotImplementedException();
        }

        public virtual void ReadStartElement(string localname, string ns)
        {
            throw new NotImplementedException();
        }

        public virtual string ReadString()
        {
            throw new NotImplementedException();
        }

        public virtual bool ReadToFollowing(string name)
        {
            throw new NotImplementedException();
        }

        public virtual bool ReadToFollowing(string localName, string namespaceURI)
        {
            throw new NotImplementedException();
        }

        public virtual bool ReadToNextSibling(string name)
        {
            throw new NotImplementedException();
        }

        public virtual bool ReadToNextSibling(string localName, string namespaceURI)
        {
            throw new NotImplementedException();
        }

        public virtual void Skip()
        {
            throw new NotImplementedException();
        }

        public abstract int AttributeCount
        {
            get;
        }

        public abstract bool IsEmptyElement
        {
            get;
        }

        public abstract string LocalName
        {
            get;
        }

        public virtual string Name
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public abstract string NamespaceURI
        {
            get;
        }

        public abstract XmlNameTable NameTable
        {
            get;
        }

        public abstract XmlNodeType NodeType
        {
            get;
        }

        public abstract string Value
        {
            get;
        }
    }
}