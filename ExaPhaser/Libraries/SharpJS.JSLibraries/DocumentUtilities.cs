using SharpJS.Dom.Elements;

namespace SharpJS.JSLibraries
{
    public class DocumentUtilities
    {
        public static void LoadExternalStylesheet(string stylesheetPath)
        {
            var jqLink = JQuery.JQuery.GetJQueryObject(new LinkElement()
            {
                Href = stylesheetPath,
                Type = "text/css",
                Relation = "stylesheet",
            });
            
        }
    }
}