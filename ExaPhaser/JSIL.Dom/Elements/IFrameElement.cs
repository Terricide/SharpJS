namespace JSIL.Dom.Elements
{
    public class IFrameElement : Element
    {
        public IFrameElement() : base("iframe")
        {
        }

        public string Source
        {
            get { return (string)this["src"]; }
            set { this["src"] = value; }
        }
    }
}