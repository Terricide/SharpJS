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

        public string Url
        {
            get { return _internalWebView.SourceURI; }
            set { _internalWebView.SourceURI = value; }
        }
    }
}