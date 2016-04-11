namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    public class CategoryAttribute : Attribute
    {
        public CategoryAttribute()
        {
            this.category = "Misc";
        }

        public CategoryAttribute(string category)
        {
            this.category = category;
        }

        public override bool Equals(object obj)
        {
            return obj is CategoryAttribute && (obj == this || ((CategoryAttribute)obj).Category == this.category);
        }

        public override int GetHashCode()
        {
            return this.category.GetHashCode();
        }

        public override bool IsDefaultAttribute()
        {
            return this.category == CategoryAttribute.Default.Category;
        }

        public static CategoryAttribute Action
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.action != null)
                {
                    result = CategoryAttribute.action;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.action == null)
                        {
                            CategoryAttribute.action = new CategoryAttribute("Action");
                        }
                    }
                    result = CategoryAttribute.action;
                }
                return result;
            }
        }

        public static CategoryAttribute Appearance
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.appearance != null)
                {
                    result = CategoryAttribute.appearance;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.appearance == null)
                        {
                            CategoryAttribute.appearance = new CategoryAttribute("Appearance");
                        }
                    }
                    result = CategoryAttribute.appearance;
                }
                return result;
            }
        }

        public static CategoryAttribute Behavior
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.behaviour != null)
                {
                    result = CategoryAttribute.behaviour;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.behaviour == null)
                        {
                            CategoryAttribute.behaviour = new CategoryAttribute("Behavior");
                        }
                    }
                    result = CategoryAttribute.behaviour;
                }
                return result;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
        }

        public static CategoryAttribute Data
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.data != null)
                {
                    result = CategoryAttribute.data;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.data == null)
                        {
                            CategoryAttribute.data = new CategoryAttribute("Data");
                        }
                    }
                    result = CategoryAttribute.data;
                }
                return result;
            }
        }

        public static CategoryAttribute Default
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.def != null)
                {
                    result = CategoryAttribute.def;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.def == null)
                        {
                            CategoryAttribute.def = new CategoryAttribute("Default");
                        }
                    }
                    result = CategoryAttribute.def;
                }
                return result;
            }
        }

        public static CategoryAttribute Design
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.design != null)
                {
                    result = CategoryAttribute.design;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.design == null)
                        {
                            CategoryAttribute.design = new CategoryAttribute("Design");
                        }
                    }
                    result = CategoryAttribute.design;
                }
                return result;
            }
        }

        public static CategoryAttribute DragDrop
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.drag_drop != null)
                {
                    result = CategoryAttribute.drag_drop;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.drag_drop == null)
                        {
                            CategoryAttribute.drag_drop = new CategoryAttribute("DragDrop");
                        }
                    }
                    result = CategoryAttribute.drag_drop;
                }
                return result;
            }
        }

        public static CategoryAttribute Focus
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.focus != null)
                {
                    result = CategoryAttribute.focus;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.focus == null)
                        {
                            CategoryAttribute.focus = new CategoryAttribute("Focus");
                        }
                    }
                    result = CategoryAttribute.focus;
                }
                return result;
            }
        }

        public static CategoryAttribute Format
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.format != null)
                {
                    result = CategoryAttribute.format;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.format == null)
                        {
                            CategoryAttribute.format = new CategoryAttribute("Format");
                        }
                    }
                    result = CategoryAttribute.format;
                }
                return result;
            }
        }

        public static CategoryAttribute Key
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.key != null)
                {
                    result = CategoryAttribute.key;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.key == null)
                        {
                            CategoryAttribute.key = new CategoryAttribute("Key");
                        }
                    }
                    result = CategoryAttribute.key;
                }
                return result;
            }
        }

        public static CategoryAttribute Layout
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.layout != null)
                {
                    result = CategoryAttribute.layout;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.layout == null)
                        {
                            CategoryAttribute.layout = new CategoryAttribute("Layout");
                        }
                    }
                    result = CategoryAttribute.layout;
                }
                return result;
            }
        }

        public static CategoryAttribute Mouse
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.mouse != null)
                {
                    result = CategoryAttribute.mouse;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.mouse == null)
                        {
                            CategoryAttribute.mouse = new CategoryAttribute("Mouse");
                        }
                    }
                    result = CategoryAttribute.mouse;
                }
                return result;
            }
        }

        public static CategoryAttribute WindowStyle
        {
            get
            {
                CategoryAttribute result;
                if (CategoryAttribute.window_style != null)
                {
                    result = CategoryAttribute.window_style;
                }
                else
                {
                    lock (CategoryAttribute.lockobj)
                    {
                        if (CategoryAttribute.window_style == null)
                        {
                            CategoryAttribute.window_style = new CategoryAttribute("WindowStyle");
                        }
                    }
                    result = CategoryAttribute.window_style;
                }
                return result;
            }
        }

        private static volatile CategoryAttribute action;

        private static volatile CategoryAttribute appearance;

        private static volatile CategoryAttribute behaviour;

        private string category;

        private static volatile CategoryAttribute data;

        private static volatile CategoryAttribute def;

        private static volatile CategoryAttribute design;

        private static volatile CategoryAttribute drag_drop;

        private static volatile CategoryAttribute focus;

        private static volatile CategoryAttribute format;

        private bool IsLocalized;

        private static volatile CategoryAttribute key;

        private static volatile CategoryAttribute layout;

        private static object lockobj = new object();

        private static volatile CategoryAttribute mouse;

        private static volatile CategoryAttribute window_style;
    }
}