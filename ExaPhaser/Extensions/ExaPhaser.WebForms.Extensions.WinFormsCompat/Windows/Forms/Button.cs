using ExaPhaser.WebForms;

namespace System.Windows.Forms
{
    public class Button : TextControl
    {
        #region Public Constructors

        public Button()
        {
            WebFormsControl = new ExaPhaser.WebForms.Controls.Button
            {
                Command = new DelegateCommand(() => Click?.Invoke(this, EventArgs.Empty)),
            };
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler Click;

        #endregion Public Events
    }
}