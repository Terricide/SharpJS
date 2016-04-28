using ExaPhaser.WebForms;
using SharpJS.Dom;

namespace System.Windows.Forms
{
    public class Form : ContainerControl
    {
        private readonly WebForm _webForm;

        // ReSharper disable once ConvertToAutoProperty
        public WebForm UnderlyingWebForm => _webForm;

        public Form()
        {
            _webForm = new WebForm();
            WebFormsControl = _webForm;
        }

        /// <summary>
        /// The title of the form. Maps to the title of the webpage in SharpJS.
        /// </summary>
        public override string Text
        {
            get { return Document.Title; }
            set { Document.Title = value; }
        }
    }
}