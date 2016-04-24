namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    public class BrowsableAttribute : Attribute
    {
        public static readonly BrowsableAttribute Default = Yes;

        public static readonly BrowsableAttribute No = new BrowsableAttribute(false);

        public static readonly BrowsableAttribute Yes = new BrowsableAttribute(true);

        private bool browsable = true;

        public BrowsableAttribute(bool browsable)
        {
        }
    }
}