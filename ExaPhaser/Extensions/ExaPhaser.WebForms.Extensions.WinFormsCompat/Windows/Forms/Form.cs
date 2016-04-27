using ExaPhaser.WebForms;

namespace System.Windows.Forms
{
    public class Form
    {
        private readonly WebForm _webForm;

        // ReSharper disable once ConvertToAutoProperty
        public WebForm UnderlyingWebForm => _webForm;

        public Form()
        {
            _webForm = new WebForm();
        }
    }
}