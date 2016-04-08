using System;
using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class TextBox : Control
    {
        public TextBox() : base()
        {
            InternalElement = new InputElement()
            {
                Type = "text",
            };
            InternalElement.Change += OnTextChanged;
        }

        public override void PerformLayout()
        {
            base.PerformLayout();
        }

        public string Text
        {
            get { return GetText(); } //We are using GetText because the text
            set { SetText(value); }
        }

        private string GetText()
        {
            return InternalElement["value"];
        }

        private void SetText(string value)
        {
            InternalElement["value"] = value;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            EventHandler handler = TextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler TextChanged;
    }
}