using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Themes;
using JSIL.Dom.Elements;

namespace WebFormsTemplate
{
    public class WebFormsApplication
    {
        public static void Main(string[] args)
        {
            //Add Foundation CSS
            var foundationCssLink = new LinkElement()
            {
                Relation = "stylesheet",
                HREF = "foundation.min.css",
            };
            //Run the application
            new WebApplication(new CSSUITheme(CSSFramework.Foundation6)).Run(new MainForm(), "formhost");
        }
    }
}