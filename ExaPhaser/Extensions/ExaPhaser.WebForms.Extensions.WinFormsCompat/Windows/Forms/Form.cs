using ExaPhaser.WebForms;
using SharpJS.Dom;

namespace System.Windows.Forms
{
    public class Form : ContainerControl
    {
        #region Private Fields

        private string _title;

        #endregion Private Fields

        #region Public Constructors

        public Form()
        {
            UnderlyingWebForm = new WebForm();
            WebFormsControl = UnderlyingWebForm;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnGotFocus(object sender, EventArgs e)
        {
            base.OnGotFocus(sender, e);
            SetFormTitle(Text); //Set title when switching between forms
        }

        #endregion Protected Methods

        #region Private Methods

        private void SetFormTitle(string title)
        {
            _title = title;
            Document.Title = title;
        }

        #endregion Private Methods

        public void Focus()
        {
            WebFormsControl.InternalJQElement.Trigger("focus");
        }

        #region Public Properties

        /// <summary>
        ///     The title of the form. Maps to the title of the webpage in SharpJS.
        /// </summary>
        public override string Text
        {
            get { return _title; }
            set { SetFormTitle(value); }
        }

        public WebForm UnderlyingWebForm { get; }

        public FormBorderStyle FormBorderStyle { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void Show()
        {
            Application.ShowNewForm(this);
        }

        public void Close()
        {
            Application.CloseForm(this);
        }

        [WebFormsCompatStubOnly]
        public void ShowDialog()
        {
            Show();
        }

        #endregion Public Methods
    }
}