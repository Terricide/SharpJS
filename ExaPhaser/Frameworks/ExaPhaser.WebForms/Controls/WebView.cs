using JSIL;
using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class WebView : Control
    {
        #region Private Fields

        private string _sourceURI;

        #endregion Private Fields

        #region Public Constructors

        public WebView() : base()
        {
            InternalElement = new IFrameElement();
        }

        #endregion Public Constructors

        #region Public Properties

        public string DocumentSource
        {
            get { return InternalJQElement.HTML(); }
            set { LoadHTML(value); }
        }

        public int Height
        {
            get { return (int)InternalElement.Height; }
            set { InternalElement.Height = value; }
        }

        public int Width
        {
            get { return (int)InternalElement.Width; }
            set { InternalElement.Width = value; }
        }

        #endregion Public Properties

        #region Public Methods

        public override void PerformLayout()
        {
            base.PerformLayout();
        }

        #endregion Public Methods

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