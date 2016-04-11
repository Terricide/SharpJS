using System;
using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class Button : TextControl
    {
        private string _text;

        public Button() : base()
        {
            InternalElement = new ButtonElement()
            {
                Class = "button",
            };
            InternalElement.Click += OnClick;
        }

        public override void PerformLayout()
        {
            base.PerformLayout();
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

        private void OnClick(object sender, EventArgs e)
        {
            EventHandler handler = Click;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler Click;
    }
}