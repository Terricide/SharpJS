using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public sealed class ImageView : Control
    {
        #region Private Fields

        private string _sourceURI;

        #endregion Private Fields

        #region Public Constructors

        public ImageView()
        {
            InternalElement = new ImageElement();
            PerformLayout();
        }

        #endregion Public Constructors

        #region Public Properties

        public string SourceURI
        {
            get { return _sourceURI; }
            set { SetImageSource(value); }
        }

        #endregion Public Properties

        #region Private Methods

        private void SetImageSource(string sourceURI)
        {
            InternalElement["src"] = sourceURI;
            _sourceURI = sourceURI;
        }

        #endregion Private Methods
    }
}