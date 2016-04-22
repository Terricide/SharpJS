using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Themes;
using JSIL.Dom;
using JSIL.Dom.Elements;

namespace WebFormsTemplate
{
    public class WebFormsApplication
    {
        public static void Main(string[] args)
        {
            //Run the application
            new WebApplication(new CSSUITheme(CSSFramework.PolyUI)).Run(new MainForm(), "webform-container");
        }
    }
}