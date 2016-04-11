namespace System.Windows.Markup
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ContentPropertyAttribute : Attribute
    {
        public ContentPropertyAttribute()
        {
        }

        public ContentPropertyAttribute(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get;

            set;
        }
    }
}