using System.IO;
using JSIL.Meta;

namespace System.Xml
{
    [JSStubOnly]
    public abstract class XmlWriter : IDisposable
    {
        public virtual void Close()
        {
            throw new NotImplementedException();
        }

        public static XmlWriter Create(Stream output)
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

        public abstract void Flush();

        public void WriteAttributeString(string localName, string value)
        {
            throw new NotImplementedException();
        }

        public void WriteElementString(string localName, string value)
        {
            throw new NotImplementedException();
        }

        public abstract void WriteEndDocument();

        public abstract void WriteEndElement();

        public abstract void WriteStartDocument();

        public void WriteStartElement(string localName)
        {
            throw new NotImplementedException();
        }

        public void WriteStartElement(string localName, string ns)
        {
            throw new NotImplementedException();
        }

        public abstract void WriteString(string text);
    }
}