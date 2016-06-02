using ExaPhaser.WebForms.Controls;

namespace System.Windows.Forms
{
    public class RichTextBox : TextControl
    {
        #region Public Constructors

        public RichTextBox()
        {
            WebFormsControl = new TextArea();
        }

        #endregion Public Constructors
    }
}