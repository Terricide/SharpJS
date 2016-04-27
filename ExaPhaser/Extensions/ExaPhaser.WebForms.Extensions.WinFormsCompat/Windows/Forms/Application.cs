using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Themes;

namespace System.Windows.Forms
{
    internal class Application
    {
        private static CSSUITheme _theme = new CSSUITheme(CSSFramework.Kubism);

        public static void SetCSSUITheme(CSSUITheme theme)
        {
            _theme = theme;
        }

        public static void Run(Form form)
        {
            var sharpJSapp = new WebApplication(_theme);
            sharpJSapp.Run();
        }
    }
}