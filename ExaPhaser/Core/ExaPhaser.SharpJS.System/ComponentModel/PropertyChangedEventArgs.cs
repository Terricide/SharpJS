using JSIL.Meta;

namespace System.ComponentModel
{
    [JSStubOnly]
    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        public string PropertyName
        {
            get
            {
                return this._propertyName;
            }

            internal set
            {
                this._propertyName = value;
            }
        }

        private string _propertyName;
    }
}