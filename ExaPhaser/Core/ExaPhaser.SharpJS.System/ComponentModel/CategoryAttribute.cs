namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    public class CategoryAttribute : Attribute
    {
        private static volatile CategoryAttribute action;

        private static volatile CategoryAttribute appearance;

        private static volatile CategoryAttribute behaviour;

        private static volatile CategoryAttribute data;

        private static volatile CategoryAttribute def;

        private static volatile CategoryAttribute design;

        private static volatile CategoryAttribute drag_drop;

        private static volatile CategoryAttribute focus;

        private static volatile CategoryAttribute format;

        private static volatile CategoryAttribute key;

        private static volatile CategoryAttribute layout;

        private static readonly object lockobj = new object();

        private static volatile CategoryAttribute mouse;

        private static volatile CategoryAttribute window_style;

        private bool IsLocalized;

        public CategoryAttribute()
        {
            Category = "Misc";
        }

        public CategoryAttribute(string category)
        {
            Category = category;
        }

        public static CategoryAttribute Action
        {
            get
            {
                CategoryAttribute result;
                if (action != null)
                {
                    result = action;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (action == null)
                        {
                            action = new CategoryAttribute("Action");
                        }
                    }
                    result = action;
                }
                return result;
            }
        }

        public static CategoryAttribute Appearance
        {
            get
            {
                CategoryAttribute result;
                if (appearance != null)
                {
                    result = appearance;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (appearance == null)
                        {
                            appearance = new CategoryAttribute("Appearance");
                        }
                    }
                    result = appearance;
                }
                return result;
            }
        }

        public static CategoryAttribute Behavior
        {
            get
            {
                CategoryAttribute result;
                if (behaviour != null)
                {
                    result = behaviour;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (behaviour == null)
                        {
                            behaviour = new CategoryAttribute("Behavior");
                        }
                    }
                    result = behaviour;
                }
                return result;
            }
        }

        public string Category { get; }

        public static CategoryAttribute Data
        {
            get
            {
                CategoryAttribute result;
                if (data != null)
                {
                    result = data;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (data == null)
                        {
                            data = new CategoryAttribute("Data");
                        }
                    }
                    result = data;
                }
                return result;
            }
        }

        public static CategoryAttribute Default
        {
            get
            {
                CategoryAttribute result;
                if (def != null)
                {
                    result = def;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (def == null)
                        {
                            def = new CategoryAttribute("Default");
                        }
                    }
                    result = def;
                }
                return result;
            }
        }

        public static CategoryAttribute Design
        {
            get
            {
                CategoryAttribute result;
                if (design != null)
                {
                    result = design;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (design == null)
                        {
                            design = new CategoryAttribute("Design");
                        }
                    }
                    result = design;
                }
                return result;
            }
        }

        public static CategoryAttribute DragDrop
        {
            get
            {
                CategoryAttribute result;
                if (drag_drop != null)
                {
                    result = drag_drop;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (drag_drop == null)
                        {
                            drag_drop = new CategoryAttribute("DragDrop");
                        }
                    }
                    result = drag_drop;
                }
                return result;
            }
        }

        public static CategoryAttribute Focus
        {
            get
            {
                CategoryAttribute result;
                if (focus != null)
                {
                    result = focus;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (focus == null)
                        {
                            focus = new CategoryAttribute("Focus");
                        }
                    }
                    result = focus;
                }
                return result;
            }
        }

        public static CategoryAttribute Format
        {
            get
            {
                CategoryAttribute result;
                if (format != null)
                {
                    result = format;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (format == null)
                        {
                            format = new CategoryAttribute("Format");
                        }
                    }
                    result = format;
                }
                return result;
            }
        }

        public static CategoryAttribute Key
        {
            get
            {
                CategoryAttribute result;
                if (key != null)
                {
                    result = key;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (key == null)
                        {
                            key = new CategoryAttribute("Key");
                        }
                    }
                    result = key;
                }
                return result;
            }
        }

        public static CategoryAttribute Layout
        {
            get
            {
                CategoryAttribute result;
                if (layout != null)
                {
                    result = layout;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (layout == null)
                        {
                            layout = new CategoryAttribute("Layout");
                        }
                    }
                    result = layout;
                }
                return result;
            }
        }

        public static CategoryAttribute Mouse
        {
            get
            {
                CategoryAttribute result;
                if (mouse != null)
                {
                    result = mouse;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (mouse == null)
                        {
                            mouse = new CategoryAttribute("Mouse");
                        }
                    }
                    result = mouse;
                }
                return result;
            }
        }

        public static CategoryAttribute WindowStyle
        {
            get
            {
                CategoryAttribute result;
                if (window_style != null)
                {
                    result = window_style;
                }
                else
                {
                    lock (lockobj)
                    {
                        if (window_style == null)
                        {
                            window_style = new CategoryAttribute("WindowStyle");
                        }
                    }
                    result = window_style;
                }
                return result;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is CategoryAttribute && (obj == this || ((CategoryAttribute) obj).Category == Category);
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