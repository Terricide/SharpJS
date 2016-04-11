namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    public sealed class EditorBrowsableAttribute : Attribute
    {
        public EditorBrowsableAttribute()
        {
        }

        public EditorBrowsableAttribute(EditorBrowsableState state)
        {
            this.State = state;
        }

        public EditorBrowsableState State
        {
            get;

            private set;
        }
    }
}