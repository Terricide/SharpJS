namespace System.Windows.Forms
{
    public class RichTextBox : TextControl
    {
        #region Public Constructors

        public RichTextBox()
        {
            WebFormsControl = new ExaPhaser.WebForms.Controls.TextArea();
        }

        #endregion Public Constructors
    }
}