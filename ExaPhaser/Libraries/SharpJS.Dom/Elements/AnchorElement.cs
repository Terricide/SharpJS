namespace SharpJS.Dom.Elements
{
    public class AnchorElement : Element
    {
        public AnchorElement() : base("a")
        {
        }

        public string Href
        {
            get { return this["href"]; }
            set { this["href"] = value; }
        }
    }
}