using JSIL;
using SharpJS.Dom;

namespace SharpJS.JSLibraries
{
    public class AjaxHelper
    {
        public delegate void AjaxResponseCallback(string data, string status, object xhr);

        public static void Get(string url, AjaxResponseCallback callback)
        {
            Verbatim.Expression("$0.get($1, {}, $2, 'text')", 
                JQuery.JQuery.JQueryStatic, url, callback);
        }
    }
}