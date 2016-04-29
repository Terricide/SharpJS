using ExaPhaser.WebForms.Controls;

namespace System.Windows.Forms
{
    public class WebBrowser : Control
    {
        private WebView _internalWebView;

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
    }
}