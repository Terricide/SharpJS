namespace JSIL.Dom.Elements
{
    public class LinkElement : Element
    {
        public LinkElement() : base("link")
        {
        }

        public string HREF
        {
            get { return (string)this["href"]; }
            set { this["href"] = value; }
        }

        public string Relation
        {
            get { return (string)this["rel"]; }
            set { this["rel"] = value; }
        }
    }
}