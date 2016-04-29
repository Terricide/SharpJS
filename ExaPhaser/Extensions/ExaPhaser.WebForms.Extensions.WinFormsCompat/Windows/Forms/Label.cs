using System.Drawing;

namespace System.Windows.Forms
{
    public class Label : TextControl
    {
        public Label()
        {
            WebFormsControl = new ExaPhaser.WebForms.Controls.TextBlock();
        }
    }
}