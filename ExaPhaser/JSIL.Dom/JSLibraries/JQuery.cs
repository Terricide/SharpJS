using JSIL.Meta;
using System;

namespace JSIL.Dom.JSLibraries
{
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
            Verbatim.Expression("console.log(element.DOMRepresentation)");
            return new JQueryObject(GetJQueryRawObject(element.DOMRepresentation));
        }

        [JSReplacement("$this.jq($rawDOMobject)")]
        private static object GetJQueryRawObject(object rawDOMobject)
        {
            throw new RequiresJSILRuntimeException();
        }
    }
}