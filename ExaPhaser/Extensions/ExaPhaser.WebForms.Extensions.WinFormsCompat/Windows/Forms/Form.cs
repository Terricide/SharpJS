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
            set { Document.Title = value; }
        }

        // ReSharper disable once ConvertToAutoProperty
        public WebForm UnderlyingWebForm => _webForm;

        #endregion Public Properties

        [WebFormsCompatStubOnly]
        public void ShowDialog()
        {
            Show();
        }

        public void Show()
        {
            Application.ShowNewForm(this);
        }
    }
}