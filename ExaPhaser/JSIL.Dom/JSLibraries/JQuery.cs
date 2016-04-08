namespace JSIL.Dom.JSLibraries
{
    public static class JQuery
    {
        static JQuery()
        {
            Verbatim.Expression("var jq = jQuery.noConflict(true)");
        }
    }
}