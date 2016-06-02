using ExaPhaser.WebForms.Controls;

namespace System.Windows.Forms
{
    public class Label : TextControl
    {
        public Label()
        {
            WebFormsControl = new TextBlock();
        }
    }
}