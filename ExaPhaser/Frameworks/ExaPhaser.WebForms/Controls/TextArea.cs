using System;
using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    /// <summary>
    /// A control with a multi-line textbox. Is represented by a TEXTAREA tag in HTML.
    /// </summary>
    public sealed class TextArea : TextControl
    {
        #region Public Constructors

        public TextArea()
        {
            InternalElement = new TextAreaElement();
            InternalElement.Change += OnTextChanged;
            InternalJQElement.EnterKeyPressed += OnEnterPressed;
            InternalJQElement.Focus += OnFocus;
            PerformLayout();
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler EnterPressed;

        public event EventHandler Focus;

        public event EventHandler TextChanged;

        #endregion Public Events

        #region Public Properties

        public int Columns
        {
            get { return int.Parse(InternalElement["cols"]); }
            set { InternalElement["cols"] = value.ToString(); }
        }

        public string PlaceholderText
        {
            get { return InternalJQElement.Attr("placeholder"); }
            set { InternalJQElement.Attr("placeholder", value); }
        }

        public int Rows
        {
            get { return int.Parse(InternalElement["rows"]); }
            set { InternalElement["rows"] = value.ToString(); }
        }

        public string Text
        {
            get { return GetText(); } //We are using GetText because the text
            set { SetText(value); }
        }
        #endregion Public Properties

        #region Private Methods

        private string GetText()
        {
            return InternalElement["value"];
        }

        private void OnEnterPressed(object sender, EventArgs e)
        {
            var handler = EnterPressed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnFocus(object sender, EventArgs e)
        {
            var handler = Focus;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            var handler = TextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void SetText(string value)
        {
            InternalElement["value"] = value;
        }

        #endregion Private Methods
    }
}