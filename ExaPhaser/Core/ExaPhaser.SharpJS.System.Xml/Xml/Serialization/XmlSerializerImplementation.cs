using System.Collections;

namespace System.Xml.Serialization
{
    public abstract class XmlSerializerImplementation
    {
        public virtual bool CanSerialize(Type type)
        {
            throw new NotImplementedException();
        }

        public virtual XmlSerializer GetSerializer(Type type)
        {
            throw new NotImplementedException();
        }

        public virtual XmlSerializationReader Reader
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual Hashtable ReadMethods
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual Hashtable TypedSerializers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual Hashtable WriteMethods
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual XmlSerializationWriter Writer
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}