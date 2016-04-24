using JSIL.Meta;

namespace System.ComponentModel
{
    [JSStubOnly]
    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; internal set; }
    }
}