using JSIL.Meta;

namespace JSIL.Dom.JSLibraries
{
    public static class JQuery
    {
        static JQuery()
        {
            Verbatim.Expression("var jq = jQuery.noConflict(true)");
        }

        public static JQueryObject GetJQueryObject(Element element)
        {
            return new JQueryObject(GetJQueryRawObject(element.DOMRepresentation));
        }

        [JSReplacement("jq($rawDOMobject)")]
        private static object GetJQueryRawObject(object rawDOMobject)
        {
            throw new RequiresJSILRuntimeException();
        }
    }
}