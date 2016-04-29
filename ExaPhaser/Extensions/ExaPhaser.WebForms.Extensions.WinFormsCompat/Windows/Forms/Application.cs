using System.Collections.Generic;
using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Themes;
using SharpJS.Dom;
using SharpJS.Dom.Elements;
using SharpJS.JSLibraries.JQuery;

namespace System.Windows.Forms
{
    public class Application
    {
        #region Private Fields

        private static List<WebForm> _forms;
        private static CSSUITheme _theme = new CSSUITheme(CSSFramework.Kubism);

        #endregion Private Fields

        #region Public Properties

        public static string HostElementId { get; set; } = "webform-container";

        #endregion Public Properties

        #region Public Methods

        [WebFormsCompatStubOnly]
        public static void EnableVisualStyles() { }

        public static void Run(Form form)
        {
            WebApplication sharpJSApp = new WebApplication(_theme);
            var mainWebForm = form.UnderlyingWebForm;
            mainWebForm.InternalJQElement.Css("position", "relative"); //To allow child control positioning
            var hostElement = Document.GetElementById(HostElementId);
            var mainFormHost = new DivElement();
            var jqMainFormHost = new JQElement(mainFormHost);
            hostElement.AppendChild(mainFormHost);
            _forms = new List<WebForm> { mainWebForm };
            sharpJSApp.Run(mainWebForm, jqMainFormHost);
            mainWebForm.InternalJQElement.AddClass("winform");
            mainWebForm.InternalJQElement.Draggable();
        }

        [WebFormsCompatStubOnly]
        public static void SetCompatibleTextRenderingDefault(bool defaultValue) { }

        public static void SetCSSUITheme(CSSUITheme theme)
        {
            _theme = theme;
        }

        internal static void CloseForm(Form formToClose)
        {
            _forms.Remove(formToClose.UnderlyingWebForm);
            formToClose.UnderlyingWebForm.InternalJQElement.Remove();
        }

        /// <summary>
        /// Creates and adds another newForm to the page.
        /// </summary>
        /// <param name="newForm"></param>
        internal static void ShowNewForm(Form newForm)
        {
            WebApplication sharpJSApp = new WebApplication(_theme);
            var hostElement = Document.GetElementById(HostElementId);
            var newFormHost = new DivElement();
            var jqMainFormHost = new JQElement(newFormHost);
            hostElement.AppendChild(newFormHost);
            var newWebForm = newForm.UnderlyingWebForm;
            _forms.Add(newWebForm);
            sharpJSApp.Run(newWebForm, jqMainFormHost);
        }
        #endregion Public Methods
    }
}