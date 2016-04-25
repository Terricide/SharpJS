using System;

namespace SharpJS.System.CodeDom.Compiler
{
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public sealed class GeneratedCodeAttribute : Attribute
    {
        public GeneratedCodeAttribute(string tool, string version)
        {
            Tool = tool;
            Version = version;
        }

        public string Tool { get; private set; }

        public string Version { get; private set; }
    }
}