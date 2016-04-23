namespace JSIL.Dom.Elements
{
    public class LinkElement : Element
    {
        public LinkElement() : base("link")
        {
        }

        public string HREF
        {
            get { return this["href"]; }
            set { this["href"] = value; }
        }

        public string Relation
        {
            get { return this["rel"]; }
            set { this["rel"] = value; }
        }
    }
}