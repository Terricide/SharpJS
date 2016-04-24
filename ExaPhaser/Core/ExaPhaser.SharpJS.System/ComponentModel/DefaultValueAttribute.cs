namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class DefaultValueAttribute : Attribute
    {
        public DefaultValueAttribute(bool value)
        {
            Value = value;
        }

        public DefaultValueAttribute(byte value)
        {
            Value = value;
        }

        public DefaultValueAttribute(char value)
        {
            Value = value;
        }

        public DefaultValueAttribute(double value)
        {
            Value = value;
        }

        public DefaultValueAttribute(short value)
        {
            Value = value;
        }

        public DefaultValueAttribute(int value)
        {
            Value = value;
        }

        public DefaultValueAttribute(long value)
        {
            Value = value;
        }

        public DefaultValueAttribute(object value)
        {
            Value = value;
        }

        public DefaultValueAttribute(float value)
        {
            Value = value;
        }

        public DefaultValueAttribute(string value)
        {
            Value = value;
        }

        public DefaultValueAttribute(Type type, string value)
        {
        }

        public object Value { get; }
    }
}