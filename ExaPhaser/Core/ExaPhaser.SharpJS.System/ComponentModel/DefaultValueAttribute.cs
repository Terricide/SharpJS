namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class DefaultValueAttribute : Attribute
    {
        public DefaultValueAttribute(bool value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(byte value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(char value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(double value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(short value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(int value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(long value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(object value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(float value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(string value)
        {
            this.DefaultValue = value;
        }

        public DefaultValueAttribute(Type type, string value)
        {
        }

        public object Value
        {
            get
            {
                return this.DefaultValue;
            }
        }

        private object DefaultValue;
    }
}