using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class TextBlock : Control
    {
        private string _text;

        public override void PerformLayout()
        {
            base.PerformLayout();
            InternalElement = new ParagraphElement();
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}