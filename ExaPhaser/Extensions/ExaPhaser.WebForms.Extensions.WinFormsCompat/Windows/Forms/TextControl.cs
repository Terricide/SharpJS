namespace System.Windows.Forms
{
    public class TextControl : Control
    {
        public override string Text
        {
            get { return WebFormsControl.Text; }
            set { WebFormsControl.Text = value; }
        }
    }
}