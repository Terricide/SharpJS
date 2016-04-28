namespace System.Windows.Forms
{
    public class TextBox : TextControl
    {
        #region Public Constructors

        public TextBox()
        {
            var internalTextBox = new ExaPhaser.WebForms.Controls.TextBox();
            internalTextBox.EnterPressed += (s, e) => EnterPressed?.Invoke(this, EventArgs.Empty);
            internalTextBox.TextChanged += (s, e) => TextChanged?.Invoke(this, EventArgs.Empty);
            WebFormsControl = internalTextBox;
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler TextChanged;

        public event EventHandler EnterPressed;

        #endregion Public Events
    }
}