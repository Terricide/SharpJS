namespace JSIL.Dom.Elements
{
    public class ScriptElement : Element
    {
        public ScriptElement() : base("script")
        {
        }

        public string Source
        {
            get { return this["src"]; }
            set { this["src"] = value; }
        }
    }
}