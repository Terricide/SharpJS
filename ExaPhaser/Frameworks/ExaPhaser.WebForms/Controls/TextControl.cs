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
            JQuery.GetJQueryObject(InternalElement).Css("font-size", newFontStyle.FontSize + "pt");
            JQuery.GetJQueryObject(InternalElement).Css("font-weight", newFontStyle.FontWeight.ToString().ToLower());
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
            set { JQuery.GetJQueryObject(InternalElement).Css("text-align", value.ToString().ToLower()); }
        }

        #endregion Public Properties
    }
}