namespace SharpJS.Dom.JSLibraries.JQElements
{
    /// <summary>
    ///     A managed wrapper for a DOM element representing a <div> node, with jQuery functionality enabled.
    /// </summary>
    public class JqDivElement : JqElement
    {
        public JqDivElement() : base(new Element("div"))
        {
        }
    }
}