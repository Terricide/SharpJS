namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        public static readonly DescriptionAttribute Default = new DescriptionAttribute();

        public DescriptionAttribute()
        {
            DescriptionValue = string.Empty;
        }

        public DescriptionAttribute(string name)
        {
            DescriptionValue = name;
        }

        public virtual string Description
        {
            get { return DescriptionValue; }
        }

        protected string DescriptionValue { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DescriptionAttribute &&
                   (obj == this || ((DescriptionAttribute) obj).Description == DescriptionValue);
        }

        public override int GetHashCode()
        {
            return DescriptionValue.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return this == Default;
        }
    }
}