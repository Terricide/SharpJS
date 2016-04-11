using JSIL.Dom.JSLibraries;
using JSIL.Dom.Styles;

namespace ExaPhaser.WebForms.Controls
{
    public class TextControl : Control
    {
        private FontStyle _fontStyle;

        public FontStyle FontStyle
        {
            set
            {
                SetFontStyle(value);
            }
        }

        public TextAlign TextAlign
        {
            set { JQuery.GetJQueryObject(InternalElement).CSS("text-align", value.ToString().ToLower()); }
        }

        public override void PerformLayout()
        {
            base.PerformLayout();
            FontStyle = new FontStyle(); //Set font style to defaults
        }

        private void SetFontStyle(FontStyle newFontStyle)
        {
            JQuery.GetJQueryObject(InternalElement).CSS("font-size", newFontStyle.FontSize + "pt");
            JQuery.GetJQueryObject(InternalElement).CSS("font-weight", newFontStyle.FontWeight.ToString().ToLower());
            _fontStyle = newFontStyle;
        }
    }
}