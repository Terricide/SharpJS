namespace System.Windows.Forms
{
    public class RichTextBox : TextControl
    {
        public RichTextBox()
        {
            WebFormsControl = new ExaPhaser.WebForms.Controls.TextArea();
        }
    }
}
