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
            #region Apply Styles to page

            //Add Foundation CSS
            var foundationCssLink = new LinkElement()
            {
                Relation = "stylesheet",
                HREF = "foundation.min.css",
            };
            var formhost = Document.GetElementById("formhost"); //Get the form host div
            var row = new DivElement() //Create Row
            {
                Class = "row",
            };
            var columns = new DivElement() //Create columns
            {
                Class = "large-12 columns",
            };
            //Create a panel/callout for the form
            var panel = new DivElement()
            {
                Class = "callout",
                Id = "formhostcontainer",
            };
            columns.AppendChild(panel);
            row.AppendChild(columns);
            formhost.AppendChild(row);
            Document.Body.AppendChild(foundationCssLink);

            #endregion Apply Styles to page

            //Run the application
            new WebApplication(new CSSUITheme(CSSFramework.Foundation6)).Run(new MainForm(), "formhostcontainer");
        }
    }
}