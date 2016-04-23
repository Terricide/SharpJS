namespace SharpJS.Dom.Elements
{
    public class AnchorElement : Element
    {
        public AnchorElement() : base("a")
        {
        }

        public string HREF
        {
            get { return this["href"]; }
            set { this["href"] = value; }
        }
    }
}