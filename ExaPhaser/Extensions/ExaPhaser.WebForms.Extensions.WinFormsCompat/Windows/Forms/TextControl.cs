using System.Drawing;
using SharpJS.Dom.Styles;

namespace System.Windows.Forms
{
    public class TextControl : Control
    {
        #region Public Properties

        public override Font Font
        {
            set { SetFont(value); }
        }

        public override Size Size
        {
            get { return ClientSize; }
            set
            {
                if (!AutoSize) //If autosize, it should not be sized manually, client browser should take of it
                {
                    ClientSize = value;
                }
            }
        }

        public override string Text
        {
            get { return WebFormsControl.Text; }
            set { WebFormsControl.Text = value; }
        }

        #endregion Public Properties

        #region Private Methods

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

        #endregion Private Methods
    }
}