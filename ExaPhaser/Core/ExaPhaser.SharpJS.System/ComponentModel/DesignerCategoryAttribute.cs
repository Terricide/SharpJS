namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DesignerCategoryAttribute : Attribute
    {
        public DesignerCategoryAttribute()
        {
            this.category = string.Empty;
        }

        public DesignerCategoryAttribute(string category)
        {
            this.category = category;
        }

        public override bool Equals(object obj)
        {
            return obj is DesignerCategoryAttribute && (obj == this || ((DesignerCategoryAttribute)obj).Category == this.category);
        }

        public override int GetHashCode()
        {
            return this.category.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return this.category == DesignerCategoryAttribute.Default.Category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
        }

        public override object TypeId
        {
            get
            {
                return base.GetType();
            }
        }

        private string category;

        public static readonly DesignerCategoryAttribute Component = new DesignerCategoryAttribute("Component");

        public static readonly DesignerCategoryAttribute Default = new DesignerCategoryAttribute(string.Empty);

        public static readonly DesignerCategoryAttribute Form = new DesignerCategoryAttribute("Form");

        public static readonly DesignerCategoryAttribute Generic = new DesignerCategoryAttribute("Designer");
    }
}