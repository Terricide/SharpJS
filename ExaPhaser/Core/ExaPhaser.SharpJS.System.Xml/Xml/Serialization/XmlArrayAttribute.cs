using System.Xml.Schema;

namespace System.Xml.Serialization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false)]
    public class XmlArrayAttribute : Attribute
    {
        public XmlArrayAttribute()
        {
        }

        public XmlArrayAttribute(string elementName)
        {
            this.elementName = elementName;
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

        public int Order
        {
            get
            {
                return this.order;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Order cannot be negative.");
                }
                this.order = value;
            }
        }

        private string elementName;

        private XmlSchemaForm form = XmlSchemaForm.None;

        private string ns;

        private bool nullable;

        private int order = -1;
    }
}