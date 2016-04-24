using SharpJS.Dom.JSLibraries;
using SharpJS.Dom.Styles;

namespace ExaPhaser.WebForms.Controls
{
    public class TextControl : Control
    {
        #region Private Fields

        private FontStyle _fontStyle;

        #endregion Private Fields

        #region Private Methods

        private void SetFontStyle(FontStyle newFontStyle)
        {
            InternalJQElement.Css("font-size", newFontStyle.FontSize + "pt");
            InternalJQElement.Css("font-weight", newFontStyle.FontWeight.ToString().ToLower());
            _fontStyle = newFontStyle;
        }

        #endregion Private Methods

        #region Public Properties

        public FontStyle FontStyle
        {
            set { SetFontStyle(value); }
        }

        public TextAlign TextAlign
        {
            set { InternalJQElement.Css("text-align", value.ToString().ToLower()); }
        }

        #endregion Public Properties
    }
}