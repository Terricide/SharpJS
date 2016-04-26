using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    /// <summary>
    /// A link label is very similar to a label; however, it usually has a hyperlink destination.
    /// </summary>
    public sealed class LinkLabel : TextControl
    {
        #region Private Fields

        private string _text;

        #endregion Private Fields

        #region Public Constructors

        public LinkLabel()
        {
            InternalElement = new AnchorElement();
            PerformLayout();
        }

        #endregion Public Constructors

        #region Public Properties

        public string Text
        {
            get { return _text; }
            set { SetText(value); }
        }

        public string LinkLocation
        {
            get { return InternalElement["href"]; }
            set { InternalElement["href"] = value; }
        }

        #endregion Public Properties

        #region Private Methods

        private void SetText(string value)
        {
            InternalElement.TextContent = value;
            _text = value;
        }

        #endregion Private Methods
    }
}