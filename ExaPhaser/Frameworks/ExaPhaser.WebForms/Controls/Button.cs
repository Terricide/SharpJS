using System;
using ExaPhaser.WebForms.Themes;
using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public sealed class Button : TextControl
    {
        #region Private Fields

        private string _text;

        #endregion Private Fields

        #region Public Constructors

        public Button()
        {
            switch (WebApplication.CurrentTheme.Stylesheet)
            {
                case CSSFramework.Foundation6:
                    InternalElement = new AnchorElement
                    {
                        Class = "button"
                    };
                    break;

                case CSSFramework.PolyUI:
                    InternalElement = new AnchorElement
                    {
                        Class = "btn--default"
                    };
                    break;

                case CSSFramework.Kubism:
                    InternalElement = new AnchorElement
                    {
                        Class = "btn"
                    };
                    break;

                default:
                    InternalElement = new AnchorElement
                    {
                        Class = "button"
                    };
                    break;
            }
            InternalElement.Click += OnClick;
            PerformLayout();
        }

        #endregion Public Constructors

        #region Public Properties

        public string Text
        {
            get { return _text; }
            set { SetText(value); }
        }

        #endregion Public Properties

        #region Public Events

        public event EventHandler Click;

        #endregion Public Events

        #region Private Methods

        private void OnClick(object sender, EventArgs e)
        {
            var handler = Click;
            handler?.Invoke(this, e);
            Command?.Execute(CommandParameter);
        }

        private void SetText(string value)
        {
            InternalElement.TextContent = value;
            _text = value;
        }

        #endregion Private Methods

        #region Command

        public ICommand Command { get; set; }

        public object CommandParameter { get; set; }

        #endregion Command
    }
}