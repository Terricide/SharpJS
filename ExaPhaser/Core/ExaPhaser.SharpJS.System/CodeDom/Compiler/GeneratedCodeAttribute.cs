namespace System.CodeDom.Compiler
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class GeneratedCodeAttribute : Attribute
    {
        public GeneratedCodeAttribute(string tool, string version)
        {
            this.Tool = tool;
            this.Version = version;
        }

        public string Tool
        {
            get;

            private set;
        }

        public string Version
        {
            get;

            private set;
        }
    }
}