using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Themes;

namespace System.Windows.Forms
{
    public class Application
    {
        private static CSSUITheme _theme = new CSSUITheme(CSSFramework.Kubism);
        private static WebForm _mainForm;
        private static WebApplication _sharpJSApp;

        public static void SetCSSUITheme(CSSUITheme theme)
        {
            _theme = theme;
        }

        public static string HostElementId { get; set; } = "webform-container";

        public static void Run(Form form)
        {
            _sharpJSApp = new WebApplication(_theme);
            _mainForm = form.UnderlyingWebForm;
            _sharpJSApp.Run(_mainForm, HostElementId);
        }
    }
}