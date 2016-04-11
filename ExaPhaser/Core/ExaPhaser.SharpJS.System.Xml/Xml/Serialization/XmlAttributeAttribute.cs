using System.Xml.Schema;

namespace System.Xml.Serialization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class XmlAttributeAttribute : Attribute
    {
        public XmlAttributeAttribute()
        {
        }

        public XmlAttributeAttribute(string attributeName)
        {
            this.attributeName = attributeName;
        }

        public XmlAttributeAttribute(Type type)
        {
            this.type = type;
        }

        public XmlAttributeAttribute(string attributeName, Type type)
        {
            this.attributeName = attributeName;
            this.type = type;
        }

        public string AttributeName
        {
            get
            {
                return (this.attributeName == null) ? string.Empty : this.attributeName;
            }

            set
            {
                this.attributeName = value;
            }
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

        private string attributeName;

        private string dataType;

        private XmlSchemaForm form = XmlSchemaForm.None;

        private string ns;

        private Type type;
    }
}