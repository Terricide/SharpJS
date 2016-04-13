namespace JSIL.Dom.JSLibraries.JQElements
{
    /// <summary>
    /// A managed wrapper for a DOM element representing a <div> node, with jQuery functionality enabled.
    /// </summary>
    public class JQDivElement : JQElement
    {
        public JQDivElement() : base(new Element("div"))
        {
        }
    }
}