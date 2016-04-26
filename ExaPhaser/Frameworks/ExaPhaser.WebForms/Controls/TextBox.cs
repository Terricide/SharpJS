using System;
using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    /// <summary>
    /// A box that a user can enter text into.
    /// </summary>
    public sealed class TextBox : TextControl
    {
        #region Public Constructors

        public TextBox()
        {
            InternalElement = new InputElement
            {
                Type = "text"
            };
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

        public string PlaceholderText
        {
            get { return InternalJQElement.Attr("placeholder"); }
            set { InternalJQElement.Attr("placeholder", value); }
        }

        public string Text
        {
            get { return GetText(); } //We are using GetText because the text
            set { SetText(value); }
        }
        public InputType TextInputType
        {
            get { return GetInputType(); }
            set { SetInputType(value); }
        }

        #endregion Public Properties

        #region Private Methods

        private InputType GetInputType()
        {
            switch (InternalElement["type"])
            {
                case "text":
                    return InputType.Text;

                case "password":
                    return InputType.Password;

                case "email":
                    return InputType.Email;

                case "number":
                    return InputType.Number;

                case "search":
                    return InputType.Search;

                default:
                    return InputType.Text;
            }
        }

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

        private void SetInputType(InputType value)
        {
            switch (value)
            {
                case InputType.Text:
                    InternalElement["type"] = "text";
                    break;

                case InputType.Password:
                    InternalElement["type"] = "password";
                    break;

                case InputType.Email:
                    InternalElement["type"] = "email";
                    break;

                case InputType.Number:
                    InternalElement["type"] = "number";
                    break;

                case InputType.Search:
                    InternalElement["type"] = "search";
                    break;
            }
        }

        private void SetText(string value)
        {
            InternalElement["value"] = value;
        }

        #endregion Private Methods
    }
}