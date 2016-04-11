namespace System
{
    public class Uri
    {
        public Uri(string uriString)
        {
            if (uriString == null)
            {
                throw new ArgumentNullException("uriString");
            }
            this.InitializeUri(uriString, false, UriKind.Absolute);
        }

        public Uri(string uriString, UriKind uriKind)
        {
            if (uriString == null)
            {
                throw new ArgumentNullException("uriString");
            }
            this.InitializeUri(uriString, false, uriKind);
        }

        private void InitializeUri(string uriString, bool dontEscape, UriKind uriKind)
        {
            this._uriKind = uriKind;
            this._originalString = ((uriString == null) ? string.Empty : uriString);
            string originalString = this._originalString;
            if (!dontEscape)
            {
            }
        }

        public override string ToString()
        {
            return this.OriginalString;
        }

        public string OriginalString
        {
            get
            {
                return this._originalString;
            }
        }

        private string _originalString;

        private UriKind _uriKind;
    }
}