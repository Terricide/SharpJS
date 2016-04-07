using JSIL.Dom;

namespace JSIL.UI
{
    public class Label : Element
    {
        public Label(string text) : base("p")
        {
            TextContent = text;
        }
    }
}