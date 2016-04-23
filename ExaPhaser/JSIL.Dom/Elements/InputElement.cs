namespace JSIL.Dom.Elements
{
    public class InputElement : Element
    {
        public InputElement() : base("input")
        {
        }

        public string Type
        {
            get { return this["type"]; }
            set { this["type"] = value; }
        }
    }
}