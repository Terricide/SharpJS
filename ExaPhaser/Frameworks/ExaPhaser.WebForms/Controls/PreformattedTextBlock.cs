using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class PreformattedTextBlock : Control
    {
        #region Private Fields

        #region Private Fields

        #region Private Fields

        private string _text;

        #endregion Private Fields

        #endregion Private Fields

        #endregion Private Fields

        #region Public Constructors

        #region Public Constructors

        #region Public Constructors

        public PreformattedTextBlock() : base()
        {
            InternalElement = new PreformattedElement();
        }

        #endregion Public Constructors

        #endregion Public Constructors

        #endregion Public Constructors

        #region Public Properties

        #region Public Properties

        #region Public Properties

        public string Text
        {
            get { return _text; }
            set { SetText(value); }
        }

        #endregion Public Properties

        #endregion Public Properties

        #endregion Public Properties

        #region Private Methods

        #region Private Methods

        #region Private Methods

        private void SetText(string value)
        {
            InternalElement.TextContent = value;
            _text = value;
        }

        #endregion Private Methods

        #endregion Private Methods

        #endregion Private Methods
    }
}