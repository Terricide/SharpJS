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
            WebFormsControl = wfLinkLabel;
        }

        #endregion Public Constructors

        #region Public Events

        protected override void OnClick(object sender, EventArgs e)
        {
            base.OnClick(sender, e);
            LinkClicked?.Invoke(this, new LinkLabelLinkClickedEventArgs());
        }

        public event LinkLabelLinkClickedEventHandler LinkClicked;

        #endregion Public Events
    }

    [WebFormsCompatStubOnly]
    public class LinkLabelLinkClickedEventArgs : EventArgs
    {
    }
}