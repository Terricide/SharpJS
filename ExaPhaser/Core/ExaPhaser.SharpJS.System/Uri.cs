using System;

namespace SharpJS.System
{
    public class Uri
    {
        #region Private Fields

        private UriKind _uriKind;

        #endregion Private Fields

        #region Public Constructors

        public Uri(string uriString)
        {
            if (uriString == null)
            {
                throw new ArgumentNullException(nameof(uriString));
            }
            InitializeUri(uriString, false, UriKind.Absolute);
        }

        public Uri(string uriString, UriKind uriKind)
        {
            if (uriString == null)
            {
                throw new ArgumentNullException(nameof(uriString));
            }
            InitializeUri(uriString, false, uriKind);
        }

        #endregion Public Constructors

        #region Public Properties

        public string OriginalString { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return OriginalString;
        }

        #endregion Public Methods

        #region Private Methods

        private void InitializeUri(string uriString, bool dontEscape, UriKind uriKind)
        {
            _uriKind = uriKind;
            OriginalString = uriString ?? string.Empty;
            var originalString = OriginalString;
            if (!dontEscape)
            {
            }
        }

        #endregion Private Methods
    }
}