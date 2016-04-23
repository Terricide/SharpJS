using ExaPhaser.WebForms.Themes;
using JSIL;
using SharpJS.Dom;
using SharpJS.Dom.JSLibraries;
using SharpJS.Dom.JSLibraries.JQElements;

namespace ExaPhaser.WebForms
{
    public class WebApplication
    {
        private JqDivElement _formHost;

        public WebApplication(CSSUITheme theme)
        {
            if (Verbatim.Expression("0") == null)
            {
                throw new RequiresJSILRuntimeException();
            }
            UITheme = theme;
            CurrentTheme = UITheme;
        }

        public CSSUITheme UITheme { get; set; }

        public static CSSUITheme CurrentTheme { get; private set; }

        public void Run(WebForm webForm, string hostElementId)
        {
            Run(webForm, new JqElement(Document.GetElementById(hostElementId)));
        }

        public void Run(WebForm webForm, JqElement hostElement)
        {
            CreateApplication(hostElement); //Create containers
            webForm.ContainerElement = _formHost.DomRepresentation; //Set container to new element
        }

        protected void CreateApplication(JqElement applicationHostElement)
        {
            CreateFormHostElement(applicationHostElement);
        }

        private void CreateFormHostElement(JqElement formHostParent)
        {
            var formHostContainer = new JqDivElement();
            _formHost = new JqDivElement();
            formHostContainer.Append(_formHost);
            switch (UITheme.Stylesheet)
            {
                case CSSFramework.Foundation6:
                    formHostContainer.AddClass("row");
                    _formHost.AddClass("large-12");
                    _formHost.AddClass("columns");
                    break;

                case CSSFramework.PolyUI:
                    formHostContainer.AddClass("grid");
                    _formHost.AddClass("centered grid__col--12");
                    break;

                case CSSFramework.Kubism:
                    formHostContainer.AddClass("wrap");
                    break;
            }
            formHostParent.Append(formHostContainer);
        }
    }
}