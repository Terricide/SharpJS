namespace System.Windows.Forms
{
    [WebFormsCompatStubOnly]
    public delegate void LinkLabelLinkClickedEventHandler(
            object sender,
            LinkLabelLinkClickedEventArgs e
            );

    public class LinkLabel : TextControl
    {
        #region Public Constructors

        public LinkLabel()
        {
            var wfLinkLabel = new ExaPhaser.WebForms.Controls.LinkLabel();
            wfLinkLabel.Click += (s, e) => LinkClicked?.Invoke(this, new LinkLabelLinkClickedEventArgs());
            WebFormsControl = wfLinkLabel;
        }

        #endregion Public Constructors

        #region Public Events

        public event LinkLabelLinkClickedEventHandler LinkClicked;

        #endregion Public Events
    }

    [WebFormsCompatStubOnly]
    public class LinkLabelLinkClickedEventArgs : EventArgs
    {
    }
}