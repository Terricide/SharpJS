namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    public class BrowsableAttribute : Attribute
    {
        public BrowsableAttribute(bool browsable)
        {
        }

        private bool browsable = true;

        public static readonly BrowsableAttribute Default = BrowsableAttribute.Yes;

        public static readonly BrowsableAttribute No = new BrowsableAttribute(false);

        public static readonly BrowsableAttribute Yes = new BrowsableAttribute(true);
    }
}