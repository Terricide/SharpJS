using SharpJS.Dom.Elements;

namespace IridiumIon.NeptuniumKit.Controls
{
    public class TextView : NKView
    {
        private string _text;

        public TextView() : base()
        {
            //Text = ""; //Don't set text to null?
            //Create <p> as underlying element
            UnderlyingElement = new ParagraphElement();
        }

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                (UnderlyingElement as ParagraphElement).TextContent = _text;
            }
        }
    }
}