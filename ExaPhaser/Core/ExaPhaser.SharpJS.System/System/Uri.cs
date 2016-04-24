namespace System
{
    public class Uri
    {
        private UriKind _uriKind;

        public Uri(string uriString)
        {
            if (uriString == null)
            {
                throw new ArgumentNullException("uriString");
            }
            InitializeUri(uriString, false, UriKind.Absolute);
        }

        public Uri(string uriString, UriKind uriKind)
        {
            if (uriString == null)
            {
                throw new ArgumentNullException("uriString");
            }
            InitializeUri(uriString, false, uriKind);
        }

        public string OriginalString { get; private set; }

        private void InitializeUri(string uriString, bool dontEscape, UriKind uriKind)
        {
            _uriKind = uriKind;
            OriginalString = uriString == null ? string.Empty : uriString;
            var originalString = OriginalString;
            if (!dontEscape)
            {
            }
        }

        public override string ToString()
        {
            return OriginalString;
        }
    }
}