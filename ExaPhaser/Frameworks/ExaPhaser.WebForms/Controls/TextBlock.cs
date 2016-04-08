using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class TextBlock : Control
    {
        private string _text;

        public override void PerformLayout()
        {
            InternalElement = new ParagraphElement();
        }

        public string Text
        {
            get { return _text; }
            set { SetText(value); }
        }

        private void SetText(string value)
        {
            InternalElement.TextContent = value;
            _text = value;
        }
    }
}