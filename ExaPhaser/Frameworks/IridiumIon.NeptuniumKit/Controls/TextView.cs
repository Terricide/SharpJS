using IridiumIon.NeptuniumKit.Controls.Properties;
using SharpJS.Dom.Elements;

namespace IridiumIon.NeptuniumKit.Controls
{
    public class TextView : NKView
    {
        private string _text;
        private FontStyle style;

        public TextView() : base()
        {
            //Text = ""; //Don't set text to null?
            //Create <p> as underlying element
            UnderlyingElement = new ParagraphElement();
            Style = new FontStyle(); //Trigger UpdateStyles()
        }

        public virtual void UpdateStyles(object sender, string propertyName)
        {
            UnderlyingJQElement.Css("font-size", $"{Style.TextSize}pt");
            switch (Style.Weight)
            {
                case FontWeight.Normal:
                    UnderlyingJQElement.Css("font-weight", "normal");
                    break;

                case FontWeight.Bold:
                    UnderlyingJQElement.Css("font-weight", "bold");
                    break;
            }
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

        public FontStyle Style
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
                style.PropertyChanged += UpdateStyles;
                UpdateStyles(null, null); //Initial style update
            }
        }
    }
}