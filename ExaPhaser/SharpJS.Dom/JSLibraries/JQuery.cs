using System;
using JSIL;
using JSIL.Meta;

namespace SharpJS.Dom.JSLibraries
{
    /// <summary>
    ///     A static jQuery class wrapping basic jQuery functionality, and providing access to static jQuery functions.
    /// </summary>
    public static class JQuery
    {
        public delegate void AjaxResponseCallback(string data, string status, object xhr);

        private static object _jq;

        static JQuery()
        {
            Initialize();
        }

        public static bool IsInitialized { get; private set; }

        public static void Initialize()
        {
            var jQueryHandle = Verbatim.Expression("jQuery.noConflict(true)");
            if (jQueryHandle == null)
            {
                throw new InvalidOperationException("Cannot use jQuery with SharpJS if the jQuery library has not been loaded.");
            }
            //JQuery successfully initialized
            IsInitialized = true;
            _jq = jQueryHandle;
        }

        public static JQueryObject GetJQueryObject(Element element)
        {
            return new JQueryObject(GetJQueryRawObject(_jq, element.DOMRepresentation));
        }

        public static JQueryObject FromSelector(string selector)
        {
            return GetJQueryObject(Document.GetElementById(selector));
        }

        [JSReplacement("$_jq($rawDoMobject)")]
        private static object GetJQueryRawObject(object _jq, object rawDoMobject)
        {
            throw new RequiresJSILRuntimeException();
        }

        public static void Get(string url, AjaxResponseCallback callback)
        {
        }
    }
}