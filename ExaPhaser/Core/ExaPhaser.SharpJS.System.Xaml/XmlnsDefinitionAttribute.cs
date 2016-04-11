namespace System.Windows.Markup
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class XmlnsDefinitionAttribute : Attribute
    {
        public XmlnsDefinitionAttribute(string xmlNamespace, string clrNamespace)
        {
            this.XmlNamespace = xmlNamespace;
            this.ClrNamespace = clrNamespace;
        }

        public string AssemblyName
        {
            get;

            set;
        }

        public string ClrNamespace
        {
            get;

            set;
        }

        public string XmlNamespace
        {
            get;

            set;
        }
    }
}