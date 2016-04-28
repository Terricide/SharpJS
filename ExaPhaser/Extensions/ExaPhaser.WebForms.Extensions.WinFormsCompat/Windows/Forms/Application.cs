using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Themes;

namespace System.Windows.Forms
{
    public class Application
    {
        #region Private Fields

        private static WebForm _mainForm;
        private static WebApplication _sharpJSApp;
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
            _sharpJSApp = new WebApplication(_theme);
            _mainForm = form.UnderlyingWebForm;
            _mainForm.InternalJQElement.Css("position", "relative"); //To allow child control positioning
            _sharpJSApp.Run(_mainForm, HostElementId);
            _mainForm.InternalJQElement.AddClass("winform");
        }

        [WebFormsCompatStubOnly]
        public static void SetCompatibleTextRenderingDefault(bool defaultValue) { }

        public static void SetCSSUITheme(CSSUITheme theme)
        {
            _theme = theme;
        }

        #endregion Public Methods
    }
}
