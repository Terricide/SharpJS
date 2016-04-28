using System.Drawing;
using SharpJS.Dom.Styles;

namespace System.Windows.Forms
{
    public class TextControl : Control
    {
        public override string Text
        {
            get { return WebFormsControl.Text; }
            set { WebFormsControl.Text = value; }
        }

        public override Font Font
        {
            set { SetFont(value); }
        }

        private void SetFont(Font newFont)
        {
            var wfFontStyle = new ExaPhaser.WebForms.FontStyle
            {
                FontSize = (int)newFont.FontSize,
            };
            switch (newFont.FontStyle)
            {
                case FontStyle.Bold:
                    wfFontStyle.FontWeight = FontWeight.Bold;
                    break;

                case FontStyle.Regular:
                    wfFontStyle.FontWeight = FontWeight.Normal;
                    break;
            }
            WebFormsControl.FontStyle = wfFontStyle;
        }
    }
}