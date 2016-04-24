namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DesignerCategoryAttribute : Attribute
    {
        public static readonly DesignerCategoryAttribute Component = new DesignerCategoryAttribute("Component");

        public static readonly DesignerCategoryAttribute Default = new DesignerCategoryAttribute(string.Empty);

        public static readonly DesignerCategoryAttribute Form = new DesignerCategoryAttribute("Form");

        public static readonly DesignerCategoryAttribute Generic = new DesignerCategoryAttribute("Designer");

        public DesignerCategoryAttribute()
        {
            Category = string.Empty;
        }

        public DesignerCategoryAttribute(string category)
        {
            Category = category;
        }

        public string Category { get; }

        public override object TypeId
        {
            get { return GetType(); }
        }

        public override bool Equals(object obj)
        {
            return obj is DesignerCategoryAttribute &&
                   (obj == this || ((DesignerCategoryAttribute) obj).Category == Category);
        }

        public override int GetHashCode()
        {
            return Category.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return Category == Default.Category;
        }
    }
}