using SharpJS.Dom;

namespace SharpJS.JSLibraries.JQuery.JQElements
{
    /// <summary>
    ///     A managed wrapper for a DOM element representing a DIV node, with jQuery functionality enabled.
    /// </summary>
    public class JQDivElement : JQElement
    {
        public JQDivElement() : base(new Element("div"))
        {
            this.Attr("tabIndex", -1);
        }
    }
}