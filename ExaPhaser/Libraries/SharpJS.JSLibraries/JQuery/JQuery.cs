using JSIL;
using JSIL.Meta;
using SharpJS.Dom;
using System;

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
            var jQueryHandle = Verbatim.Expression("jQuery.noConflict()");
            if (jQueryHandle == null)
            {
                throw new InvalidOperationException("Cannot use jQuery with SharpJS if the jQuery library has not been loaded.");
            }
            //JQuery successfully initialized
            IsInitialized = true;
            _jq = jQueryHandle;
        }

        /// <summary>
        /// Gets a JQueryObject instance from an Element instance
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static JQueryObject GetJQueryObject(Element element)
        {
            return new JQueryObject(GetJQueryRawObject(_jq, element.DomObjectHandle));
        }

        public static JQueryObject FromSelector(string selector)
        {
            return new JQueryObject(GetJQuerySelectorGroup(_jq, selector));
        }

        [JSReplacement("$jqHandle($jqSelector)")]
        private static object GetJQuerySelectorGroup(object jqHandle, string jqSelector)
        {
            throw new RequiresJSILRuntimeException();
        }

        /// <summary>
        /// Gets a jQuery object from an object parameter
        /// </summary>
        /// <param name="jqHandle"></param>
        /// <param name="rawDomObject"></param>
        /// <returns></returns>
        [JSReplacement("$jqHandle($rawDomObject)")]
        private static object GetJQueryRawObject(object jqHandle, object rawDomObject)
        {
            throw new RequiresJSILRuntimeException();
        }

        /// <summary>
        /// A method that dynamically invokes a method of $ using JavaScript apply(). For example, you could run $.eatACookie() by passing
        /// eatACookie as the method name
        /// </summary>
        /// <param name="methodName">The name of the method to invoke (on jQuery object ($))</param>
        /// <param name="parameters">The parameters for the method invocation</param>
        /// <returns></returns>
        public static object DynamicInvoke(string methodName, params object[] parameters)
        {
            object targetMethod = Verbatim.Expression("$0[$1]", _jq, methodName);
            return Verbatim.Expression("$0.apply($1, $2)", null, parameters);
        }
    }
}