using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class PreformattedTextBlock : Control
    {
        #region Private Fields

        private string _text;

        #endregion Private Fields

        #region Public Constructors

        public PreformattedTextBlock() : base()
        {
            InternalElement = new PreformattedElement();
        }

        #endregion Public Constructors

        #region Public Properties

        public string Text
        {
            get { return _text; }
            set { SetText(value); }
        }

        #endregion Public Properties

        #region Public Methods

        public override void PerformLayout()
        {
            base.PerformLayout();
        }

        #endregion Public Methods

        #region Private Methods

        private void SetText(string value)
        {
            InternalElement.TextContent = value;
            _text = value;
        }

        #endregion Private Methods
    }
}
