using JSIL;
using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class WebView : Control
    {
        #region Private Fields

        private string _sourceURI;

        #endregion Private Fields

        #region Public Constructors

        public WebView()
        {
            InternalElement = new IFrameElement();
            PerformLayout();
        }

        #endregion Public Constructors

        #region Public Properties

        public string DocumentSource
        {
            get { return InternalJQElement.Html(); }
            set { LoadHTML(value); }
        }

        public string SourceURI
        {
            get { return _sourceURI; }
            set { LoadURI(value); }
        }

        #endregion Public Properties

        #region Private Methods

        public void LoadHTML(string html)
        {
            Verbatim.Expression("this.InternalJQElement.Contents().find('html').html(html)");
            _sourceURI = null;
        }

        public void LoadURI(string uri)
        {
            InternalElement["src"] = uri;
            _sourceURI = uri;
        }

        #endregion Private Methods
    }
}