using ExaPhaser.WebForms.Controls;

namespace System.Windows.Forms
{
    public class WebBrowser : Control
    {
        private readonly WebView _internalWebView;

        #region Public Constructors

        public WebBrowser()
        {
            var wfWebView = new WebView();
            _internalWebView = wfWebView;
            WebFormsControl = _internalWebView;
        }

        #endregion Public Constructors

        public Uri Url
        {
            get { return new Uri(_internalWebView.SourceURI, UriKind.Absolute); }
            set { _internalWebView.SourceURI = value.ToString(); }
        }

        public string DocumentSource
        {
            get { return _internalWebView.DocumentSource; }
            set { _internalWebView.DocumentSource = value; }
        }
    }
}