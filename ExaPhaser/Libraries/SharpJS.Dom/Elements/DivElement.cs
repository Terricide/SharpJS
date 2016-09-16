namespace SharpJS.Dom.Elements
{
    /// <summary>
    ///     A managed wrapper for a DOM element representing a DIV node.
    /// </summary>
    public class DivElement : Element
    {
        public DivElement() : base("div")
        {
            this["tabIndex"] = "-1";
        }
    }
}