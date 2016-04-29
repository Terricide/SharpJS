using System.Drawing;

namespace System.Windows.Forms
{
    public class Label : TextControl
    {
        public Label()
        {
            WebFormsControl = new ExaPhaser.WebForms.Controls.TextBlock();
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
    }
}