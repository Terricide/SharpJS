namespace JSIL.Dom.Elements
{
    public class IFrameElement : Element
    {
        public IFrameElement() : base("iframe")
        {
        }

        public string Source
        {
            get { return this["src"]; }
            set { this["src"] = value; }
        }
    }
}