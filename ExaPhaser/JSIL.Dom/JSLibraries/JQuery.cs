using System;
using JSIL.Meta;

namespace JSIL.Dom.JSLibraries
{
    /// <summary>
    /// A static jQuery class wrapping basic jQuery functionality
    /// </summary>
    public static class JQuery
    {
        private static bool _isInitialized;
        private static object jq = null;

        public static bool IsInitialized
        {
            get
            {
                return _isInitialized;
            }
        }

        public static void Initialize()
        {
            object jQueryHandle = Verbatim.Expression("jQuery.noConflict(true)");
            if (jQueryHandle == null)
            {
                throw new InvalidOperationException("Cannot use jQuery with SharpJS if the jQuery library has not been loaded.");
            }
            else
            {
                //JQuery successfully initialized
                _isInitialized = true;
                jq = jQueryHandle;
            }
        }

        public static JQueryObject GetJQueryObject(Element element)
        {
            return new JQueryObject(GetJQueryRawObject(jq, element.DOMRepresentation));
        }

        [JSReplacement("$_jq($rawDOMobject)")]
        private static object GetJQueryRawObject(object _jq, object rawDOMobject)
        {
            throw new RequiresJSILRuntimeException();
        }
    }
}