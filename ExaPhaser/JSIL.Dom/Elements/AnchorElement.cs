namespace JSIL.Dom.Elements
{
    public class AnchorElement : Element
    {
        public AnchorElement() : base("a")
        {
        }

        public string HREF
        {
            get { return (string)this["href"]; }
            set { this["href"] = value; }
        }
    }
}