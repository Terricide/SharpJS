using ExaPhaser.WebForms.Themes;
using JSIL.Dom;
using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms
{
    public class WebApplication
    {
        private CSSUITheme _uitheme;
        private DivElement _formHost;

        public WebApplication(CSSUITheme theme)
        {
            _uitheme = theme;
        }

        public void Run(WebForm webForm, string hostElementId)
        {
            Run(webForm, Document.GetElementById(hostElementId));
        }

        public void Run(WebForm webForm, Element hostElement)
        {
            CreateApplication(hostElement);
        }

        protected void CreateApplication(Element applicationHostElement)
        {
            CreateFormHostElement(applicationHostElement);
        }

        private void CreateFormHostElement(Element formHostParent)
        {
            var formHostContainer = new DivElement();
            _formHost = new DivElement();
            formHostContainer.AppendChild(_formHost);
            switch (_uitheme.Stylesheet)
            {
                case CSSFramework.Foundation6:
                    formHostContainer.AddClass("row");
                    _formHost.AddClass("large-12");
                    _formHost.AddClass("columns");
                    break;
            }
            formHostParent.AppendChild(formHostContainer);
        }
    }
}