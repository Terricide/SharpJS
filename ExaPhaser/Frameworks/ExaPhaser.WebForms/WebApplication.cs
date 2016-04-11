using ExaPhaser.WebForms.Themes;
using JSIL.Dom;
using JSIL.Dom.JSLibraries;
using JSIL.Dom.JSLibraries.JQElements;

namespace ExaPhaser.WebForms
{
    public class WebApplication
    {
        private CSSUITheme _uitheme;
        private JQDivElement _formHost;

        public CSSUITheme UITheme
        {
            get
            {
                return _uitheme;
            }

            set
            {
                _uitheme = value;
            }
        }

        public WebApplication(CSSUITheme theme)
        {
            if (!JQuery.IsInitialized)
            {
                JQuery.Initialize();
            }
            _uitheme = theme;
        }

        public void Run(WebForm webForm, string hostElementId)
        {
            Run(webForm, new JQElement(Document.GetElementById(hostElementId)));
        }

        public void Run(WebForm webForm, JQElement hostElement)
        {
            CreateApplication(hostElement); //Create containers
            webForm.ContainerElement = _formHost.DOMRepresentation; //Set container to new element
            webForm.ApplicationContext = this;
        }

        protected void CreateApplication(JQElement applicationHostElement)
        {
            CreateFormHostElement(applicationHostElement);
        }

        private void CreateFormHostElement(JQElement formHostParent)
        {
            var formHostContainer = new JQDivElement();
            _formHost = new JQDivElement();
            formHostContainer.Append(_formHost);
            switch (_uitheme.Stylesheet)
            {
                case CSSFramework.Foundation6:
                    formHostContainer.AddClass("row");
                    _formHost.AddClass("large-12");
                    _formHost.AddClass("columns");
                    break;
            }
            formHostParent.Append(formHostContainer);
        }
    }
}