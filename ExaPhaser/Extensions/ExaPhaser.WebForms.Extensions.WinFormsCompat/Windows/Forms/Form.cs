using ExaPhaser.WebForms;
using SharpJS.Dom;

namespace System.Windows.Forms
{
    public class Form : ContainerControl
    {
        #region Private Fields

        private readonly WebForm _webForm;

        #endregion Private Fields

        #region Public Constructors

        public Form()
        {
            _webForm = new WebForm();
            WebFormsControl = _webForm;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// The title of the form. Maps to the title of the webpage in SharpJS.
        /// </summary>
        public override string Text
        {
            get { return Document.Title; }
            set { SetFormTitle(value); }
        }

        // ReSharper disable once ConvertToAutoProperty
        public WebForm UnderlyingWebForm => _webForm;

        #endregion Public Properties

        #region Public Methods

        public void Show()
        {
            Application.ShowNewForm(this);
        }

        [WebFormsCompatStubOnly]
        public void ShowDialog()
        {
            Show();
        }

        #endregion Public Methods

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
            Document.Title = title;
        }

        #endregion Private Methods
    }
}