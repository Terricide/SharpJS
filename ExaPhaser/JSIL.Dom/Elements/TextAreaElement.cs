namespace JSIL.Dom.Elements
{
    public class TextAreaElement : Element
    {
        public TextAreaElement() : base("textarea")
        {
        }

        public int Rows
        {
            get { return int.Parse(this["rows"]); }
            set { this["rows"] = value.ToString(); }
        }

        public int Columns
        {
            get { return int.Parse(this["cols"]); }
            set { this["cols"] = value.ToString(); }
        }
    }
}