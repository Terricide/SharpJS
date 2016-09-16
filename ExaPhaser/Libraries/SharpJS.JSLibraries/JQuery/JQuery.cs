using System;
using JSIL;
using JSIL.Meta;
using SharpJS.Dom;

namespace SharpJS.JSLibraries.JQuery
{
    /// <summary>
    /// A static jQuery class wrapping basic jQuery functionality, and providing access to static jQuery functions.
    /// </summary>
    public static class JQuery
    {
        private static object _jq;

        static JQuery()
        {
            Initialize();
        }

        public static bool IsInitialized { get; private set; }

        // ReSharper disable once ConvertToAutoPropertyWhenPossible
        public static object JQueryStatic
        {
            get { return _jq; }
            set { _jq = value; }
        }

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
            return new JQueryObject(GetJQuerySelectorGroup(_jq, selector));
        }

        [JSReplacement("$jqHandle($rawDoMobject)")]
        private static object GetJQuerySelectorGroup(object jqHandle, string jqSelector)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$jqHandle($rawDoMobject)")]
        private static object GetJQueryRawObject(object jqHandle, object rawDoMobject)
        {
            throw new RequiresJSILRuntimeException();
        }

        public static object DynamicInvoke(string methodName, params object[] parameters)
        {
            object targetMethod = Verbatim.Expression("$0[$1]", _jq, methodName);
            return Verbatim.Expression("$0.apply($1, $2)", null, parameters);
        }
    }
}