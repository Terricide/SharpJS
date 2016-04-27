using JSIL;
using SharpJS.Dom;

namespace SharpJS.JSLibraries
{
    public class Ajax
    {
        public delegate void AjaxResponseCallback(string data, string status, object xhr);

        public static void Get(string url, AjaxResponseCallback callback)
        {
			Get(url, "{}", callback);
        }

		public static void Get(string url, string data, AjaxResponseCallback callback)
		{
			Verbatim.Expression("$0.get($1, $2, $3, 'text')",
				JQuery.JQuery.JQueryStatic, url, data, callback);
		}

		public static void Post(string url, AjaxResponseCallback callback)
		{
			Post(url, "{}", callback);
		}

		public static void Post(string url, string data, AjaxResponseCallback callback)
		{
			Verbatim.Expression("$0.get($1, $2, $3, 'text')",
				JQuery.JQuery.JQueryStatic, url, data, callback);
		}
    }
}