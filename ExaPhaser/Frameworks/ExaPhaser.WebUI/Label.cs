using JSIL.Dom;

namespace ExaPhaser.WebUI
{
    public class Label : Element
    {
        public Label(string text) : base("p")
        {
            TextContent = text;
        }
    }
}