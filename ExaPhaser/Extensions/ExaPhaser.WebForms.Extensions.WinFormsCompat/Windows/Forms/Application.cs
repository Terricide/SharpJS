using System.Collections.Generic;
using System.Drawing;
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

        private static readonly Dictionary<WebForm, DivElement> Forms = new Dictionary<WebForm, DivElement>();
        private static readonly CSSUITheme Theme = new CSSUITheme(CSSFramework.Bootstrap);

        #endregion Private Fields

        #region Public Properties

        public static string HostElementId { get; set; } = "webform-container";

        #endregion Public Properties

        #region Public Methods

        [WebFormsCompatStubOnly]
        public static void EnableVisualStyles() { }

        public static void Run(Form form)
        {
            ShowNewForm(form);
        }

        [WebFormsCompatStubOnly]
        public static void SetCompatibleTextRenderingDefault(bool defaultValue) { }

        #endregion Public Methods

        #region Internal Methods

        internal static void CloseForm(Form formToClose)
        {
            var fWebForm = formToClose.UnderlyingWebForm;
            var divHost = Forms[fWebForm];
            Forms.Remove(fWebForm);
            formToClose.UnderlyingWebForm.InternalJQElement.Remove();
            var hostElement = Document.GetElementById(HostElementId);
            hostElement.RemoveChild(divHost);
        }

        /// <summary>
        /// Creates and adds another newForm to the page.
        /// </summary>
        /// <param name="newForm"></param>
        internal static void ShowNewForm(Form newForm)
        {
            WebApplication sharpJSApp = new WebApplication(Theme);
            var hostElement = Document.GetElementById(HostElementId);
            var newFormHost = new DivElement();
            var jqMainFormHost = new JQElement(newFormHost);
            hostElement.AppendChild(newFormHost);
            var newWebForm = newForm.UnderlyingWebForm;
            newWebForm.InternalJQElement.Css("position", "relative"); //To allow child control positioning
            Forms.Add(newWebForm, newFormHost);
            sharpJSApp.Run(newWebForm, jqMainFormHost);
            InitializeWinFormWFStyles(newWebForm);
            InitializeWebUIElement(newForm);
        }

        #endregion Internal Methods

        #region Private Methods

        private static void InitializeWebUIElement(Form newForm)
        {
            //Add a close button
            var closeButton = new Button { Text = "x", Location = new Point(5, 5) };
            closeButton.Click += (s, e) => CloseForm(newForm);
            newForm.Controls.Add(closeButton);

            //Call the initialized event
            newForm.OnInitialized();
            var halfWidth = Document.ClientWidth / 2;
            var halfHeight = Document.ClientHeight / 2;
            var newFormHalfWidth = newForm.Size.Width / 2;
            var newFormHalfHeight = newForm.Size.Height / 2;
            newForm.Location = new Point(halfWidth - newFormHalfWidth, halfHeight - newFormHalfHeight); //Center the form
            newForm.Focus();
            if (newForm.FormBorderStyle == FormBorderStyle.Sizable)
            {
                newForm.UnderlyingWebForm.InternalJQElement.ResizableAnimated();
            }
        }

        private static void InitializeWinFormWFStyles(WebForm mainWebForm)
        {
            mainWebForm.InternalJQElement.AddClass("winform");
            mainWebForm.InternalJQElement.Draggable();
        }

        #endregion Private Methods
    }
}