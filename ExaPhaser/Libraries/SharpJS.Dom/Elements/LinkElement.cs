namespace SharpJS.Dom.Elements
{
    public class LinkElement : Element
    {
        public LinkElement() : base("link")
        {
        }

        public string Href
        {
            get { return this["href"]; }
            set { this["href"] = value; }
        }

        public string Type
        {
            get { return this["type"]; }
            set { this["type"] = value; }
        }

        public string Relation
        {
            get { return this["rel"]; }
            set { this["rel"] = value; }
        }
    }
}