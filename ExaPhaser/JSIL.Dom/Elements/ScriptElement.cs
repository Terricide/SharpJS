namespace JSIL.Dom.Elements
{
    public class ScriptElement : Element
    {
        public ScriptElement() : base("script")
        {
        }

        public string Source
        {
            get { return (string)this["src"]; }
            set { this["src"] = value; }
        }
    }
}